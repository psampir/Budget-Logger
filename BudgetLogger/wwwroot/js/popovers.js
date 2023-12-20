// Function to show popovers on hover
function showPopoversOnHover() {
    const popovers = document.querySelectorAll('[data-bs-toggle="popover"]');
    popovers.forEach(popover => {
        const popoverInstance = bootstrap.Popover.getInstance(popover);
        if (popoverInstance) {
            popover.addEventListener('mouseenter', function() {
                popoverInstance.show();
            });
            popover.addEventListener('mouseleave', function() {
                popoverInstance.hide();
            });
        }
    });
}

// Function to hide popovers on scroll
function hidePopoversOnDivScroll() {
    const divElement = document.querySelector('#x');
    divElement.addEventListener('scroll', hidePopovers);
    divElement.addEventListener('touchmove', hidePopovers);
}

// Function to hide popovers
function hidePopovers() {
    const popovers = document.querySelectorAll('[data-bs-toggle="popover"]');
    popovers.forEach(popover => {
        const popoverInstance = bootstrap.Popover.getInstance(popover);
        if (popoverInstance && popoverInstance._activeTrigger.click) {
            popoverInstance.hide();
        }
    });
}

// Function to hide popovers on button click by ID
function hidePopoversOnButtonClick(buttonID) {
    const button = document.getElementById(buttonID);
    button.addEventListener('click', hidePopovers);
}

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

    // Hide popovers when clicking on a button with a specific ID
    hidePopoversOnButtonClick('addButton');
    hidePopoversOnButtonClick('deleteButton');

    // Show popovers on hover
    showPopoversOnHover();
});
