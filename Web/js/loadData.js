function limitCharacters(text, maxLength) {
  if (text.length <= maxLength) {
    return text; // Trả về chuỗi nguyên vẹn nếu không vượt quá giới hạn
  } else {
    return text.substring(0, maxLength) + "..."; // Cắt chuỗi và thêm dấu ba chấm ở cuối
  }
}

function formatMoney(value) {
  if (value < 1000000) {
    // Nếu giá trị nhỏ hơn 1 triệu, chuyển đổi sang định dạng dưới 1 triệu
    return `${(value / 1000)
      .toFixed(0)
      .replace(/\B(?=(\d{3})+(?!\d))/g, ".")} nghìn đồng/tháng`;
  } else {
    // Nếu giá trị lớn hơn hoặc bằng 1 triệu, chuyển đổi sang định dạng trên 1 triệu
    if (value % 1000000 === 0) {
      return `${Math.floor(value / 1000000)} triệu đồng/tháng`;
    } else {
      return `${(value / 1000000).toFixed(1)} triệu đồng/tháng`;
    }
  }
}

const loadData = () => {
  fetch("https://localhost:7140/api/Room")
    .then((response) => response.json())
    .then((data) => {
      console.log(data);
      let htmlContent = "";
      data.data.forEach((room) => {
        htmlContent += `<div class="col mb-5">
          <div class="card h-100">
            <div class="row g-0">
              <!-- Product image-->
              <div class="col-md-4 position-relative" style="height: 350px">
                <img
                  class="card-img-top"
                  src="image/rooms/${
                    room.images[0] ||
                    "https://dummyimage.com/450x300/dee2e6/6c757d.jpg"
                  }"
                  alt="..."
                  height="100%"
                />
                <div class="position-absolute bottom-0 start-0 bg-white text-dark p-2 m-2">
                  ${room.images.length} ảnh 
                </div>
                <span class="position-absolute bottom-0 end-0 text-danger m-2 heart-icon" style="font-size: 2rem; right: 0; bottom: 0;" onclick="toggleHeart(this)" onhol>
                  <img src="image/icon/unLike.png" alt="heart" style="width: 30px; height: 30px;" class="">
                </span>
              </div>
              <!-- Product details-->
              <div class="col-md-8 d-flex flex-column" style="height: 100%;">
                <div class="card-body ps-4 d-flex flex-column">
                  <div>
                    <!-- Product name-->
                    <h5 class="fw-bolder text-primary">${room.name}</h5><br/>
                    <!-- Product price-->
                    <div class="d-flex align-items-center">
                      <p class="me-5 text-success fs-4 fw-bolder">${formatMoney(
                        room.price
                      )}</p>
                      <p class="me-3 ms-5 fs-5 fw-bolder text-">Diện tích:<span class="">${
                        room.area
                      } m²</span></p>
                      <p class="ms-auto">${new Date(
                        room.publicDate
                      ).toLocaleDateString()}</p>
                    </div>
                    <p class="fs-5 fw-bolder" >${room.ward}, ${
          room.district
        }, ${room.province}</p>
                    <div>
                      <p>${limitCharacters(room.description, 300)}</p>
                    </div>
                  </div>
                </div>
                <div class="actor mt-auto ms-4 mb-2"> 
                  <div class="actor d-flex align-items-center ">
                      <img src="image/icon/avatar.png" class="rounded-circle me-3" alt="actor name" style="width: 50px; height: 50px;">
                      <h5 class="mb-0">${room.actorName || "Actor Name"}</h5>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>`;
      });
      document.querySelector(".row").innerHTML = htmlContent;
    })
    .catch((error) => {
      console.error("Error fetching data: ", error);
    });
};
loadData();
