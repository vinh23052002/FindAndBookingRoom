function toggleHeart(element) {
  if (element.children[0].classList.contains("like")) {
    element.children[0].src = "image/icon/unLike.png";
    element.children[0].classList.remove("like");
  } else {
    element.children[0].src = "image/icon/like.png";
    element.children[0].classList.add("like");
  }
}

const heartIcon = document.querySelector(".heart-icon img");

heartIcon.addEventListener("mouseenter", function () {
  this.src = "image/icon/like.png"; // Change to red heart
});

heartIcon.addEventListener("mouseleave", function () {
  if (this.classList.contains("like")) return;
  this.src = "image/icon/unLike.png"; // Change back to default heart
});
