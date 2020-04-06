var initialYear = null;

function next(direction) {
    initialYear = direction === 'left' ? initialYear - 1 : initialYear + 1;

    $.get('/Home/GetCarouselData/?year=' + initialYear)
        .then(function (response) {
            populateCarousel(response);
        });
}

function populateCarousel(response) {
    var $carousel = $('#carouselExampleIndicators');
    var $carouselInner = $carousel.find('.carousel-inner');
    var template = '';

    $carouselInner.empty();

    response.forEach(function (item, i) {
        template += i === 0 ? populateTemplate(response[0]) : populateTemplate(item);
    });

    $carouselInner.append(template);
    $carousel.carousel();
    $carousel.carousel("pause");
    initialYear = response[0].year;
}

function populateTemplate(item) {
    var template = '';
    template = '<div class="carousel-item col-12 col-sm-6 col-md-4 col-lg-3 active">';
    template += '<a href="/Info/MovieInfo/?id='+ item.id + '">';
    template += '<img src="' + item.imageUrl + '" onerror="this.onerror=null; this.src=\'img/default.jpg\'" class="img-fluid mx-auto d-block imgResize">';
    template += '</a>';
    template += '<div class="ipc-poster-card__rating-star-group">' +
        '<span class="ipc-rating-star ipc-rating-star--baseAlt ipc-rating-star">' +
        '<svg width="24" height="24" xmlns="http://www.w3.org/2000/svg" class="ipc-icon ipc-icon--star-inline" viewBox="0 0 24 24" fill="currentColor" role="presentation" style="margin-top: -10px;">' +
        '<path d="M12 20.1l5.82 3.682c1.066.675 2.37-.322 2.09-1.584l-1.543-6.926 5.146-4.667c.94-.85.435-2.465-.799-2.567l-6.773-.602L13.29.89a1.38 1.38 0 0 0-2.581 0l-2.65 6.53-6.774.602C.052 8.126-.453 9.74.486 10.59l5.147 4.666-1.542 6.926c-.28 1.262 1.023 2.26 2.09 1.585L12 20.099z"></path>' +
        '</svg>' +
        '<span style="padding: 5px; font-size: x-large;">' + item.rating + '</span>' +
        '</span>' +
        '</div>';
    template += '<div><strong><a href="/Info/MovieInfo/?id=' + item.id + '">' + item.title + '</a></strong></div>';
    template += '</div>';

    return template;
}

$.get('/Home/GetCarouselData/')
    .then(function (response) {

        populateCarousel(response);

    });