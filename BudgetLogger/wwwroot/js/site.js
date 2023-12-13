const popoverTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="popover"]'));
popoverTriggerList.map(function (popoverTriggerEl) {
    return new bootstrap.Popover(popoverTriggerEl)
});
$(document).ready(function () {
    $('[data-bs-toggle="popover"]').popover({
        trigger: 'click'
    }).on('click', function (e) {
        // Hide other popovers when a new one is clicked
        $('[data-bs-toggle="popover"]').not(this).popover('hide');
    });
});