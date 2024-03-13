// Get data from cookie
function getTokenFromCookie(cookieName) {
  const cookies = document.cookie.split(";");
  for (let i = 0; i < cookies.length; i++) {
    const cookie = cookies[i].trim();
    if (cookie.startsWith(cookieName + "=")) {
      return cookie.substring(cookieName.length + 1);
    }
  }
  return null;
}
// Get User from token----------------------------------------------------------------
function parseJwt(token) {
  try {
    const base64Url = token.split(".")[1];
    const base64 = base64Url.replace(/-/g, "+").replace(/_/g, "/");
    const jsonPayload = decodeURIComponent(
      atob(base64)
        .split("")
        .map(function (c) {
          return "%" + ("00" + c.charCodeAt(0).toString(16)).slice(-2);
        })
        .join("")
    );

    return JSON.parse(jsonPayload);
  } catch (error) {
    console.error("Không thể giải mã token:", error);
    return null;
  }
}
var token = getTokenFromCookie("token");
var userID = parseJwt(token).userID;
var user;
var config = {
  method: "GET",
  headers: {
    "Content-Type": "application/json",
    Authorization: `Bearer ${token}`,
  },
};
const loadUser = async () => {
  try {
    const response = await fetch(
      `https://localhost:7140/api/User/${userID}`,
      config
    );
    const data = await response.json();
    user = data.data;
  } catch (err) {
    console.error("Lỗi khi tải thông tin người dùng:", error);
  }
};

const getUser = () => {
  return user;
};

//---------------------------------------------------------------------------------------
export { loadUser, getUser, getTokenFromCookie };
