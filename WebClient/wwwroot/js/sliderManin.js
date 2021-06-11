$(".sliderBanner").owlCarousel({
    items: 1,
    loop: true,
    nav: true,
    navText: [
        '<span class="fas fa-chevron-left" style="color: white;" ></span>',
        '<span class="fas fa-chevron-right" style="color: white;"></span>',
    ],
    autoplay: true,
    autoplayTimeout: 3000,
    autoplaySpeed: 1300,
    autoplayHoverPause: true,
    navSpeed: 1300,
    center: true,
});