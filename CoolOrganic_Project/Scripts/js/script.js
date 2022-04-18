const toTop = document.querySelector(".backtop");

window.addEventListener("scroll", () => {
  if (window.pageYOffset > 200) {
    toTop.classList.add("show");
  } else {
    toTop.classList.remove("show");
  }
});

/* ------------------------------------DETAIL-PRODUCT------------------------------------------- */
$(document).ready(function () {
  $(".small-image img").click(function () {
    var image = $(this).attr("src");
    $(".big-image img").attr("src", image);
  });

  $("#img_01").imagezoomsl({
    zoomrange: [4, 4],
  });
});
