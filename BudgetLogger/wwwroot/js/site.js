// Function to hide popovers on scroll within the specific div
function hidePopoversOnDivScroll() {
    const divElement = document.querySelector('#x'); // Change this selector to match your specific div
    divElement.addEventListener('scroll', hidePopovers);
    divElement.addEventListener('touchmove', hidePopovers); // Adding touchmove event for touch-based devices
}

function hidePopovers() {
    const popovers = document.querySelectorAll('[data-bs-toggle="popover"]');
    popovers.forEach(popover => {
        const popoverInstance = bootstrap.Popover.getInstance(popover);
        if (popoverInstance && popoverInstance._activeTrigger.click) {
            popoverInstance.hide();
        }
    });
}

// Initializing Bootstrap Popovers
const popoverTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="popover"]'));
popoverTriggerList.map(function (popoverTriggerEl) {
    return new bootstrap.Popover(popoverTriggerEl);
});

// Handling Popover Behavior
$(document).ready(function () {
    // Initializing Popovers to Trigger on Click
    $('[data-bs-toggle="popover"]').popover({
        trigger: 'click'
    }).on('click', function (e) {
        // Hiding Other Popovers when a New One is Clicked
        $('[data-bs-toggle="popover"]').not(this).popover('hide');
    });

    // Hiding popovers on scroll or touchmove
    hidePopoversOnDivScroll();
});
