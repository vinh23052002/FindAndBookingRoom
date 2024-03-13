const Logout = () => {
  // remove token from cookie
  document.cookie = "token=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";
  document.cookie = "email=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";
  document.cookie = "fullName=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";
  document.cookie = "phone=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";
  window.location.href = "login.html";
};
