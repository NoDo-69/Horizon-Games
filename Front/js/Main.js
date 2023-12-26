let currentSlide = 0;

function showSlide(n) {
    const slides = document.getElementsByClassName('slide');
    
    if (n >= slides.length) {
        currentSlide = 0;
    } else if (n < 0) {
        currentSlide = slides.length - 1;
    } else {
        currentSlide = n;
    }

    for (let i = 0; i < slides.length; i++) {
        slides[i].classList.remove('active');
    }

    slides[currentSlide].classList.add('active');
}

function changeSlide(n) {
    showSlide(currentSlide + n);
}

setInterval(() => {
    changeSlide(1);
}, 5000);

showSlide(currentSlide);





