$(document).ready(function() {
    // Dodanie reguł walidacji
    $("#transactionForm").validate({
        rules: {
            amount: {
                required: true,
                number: true,
                min: -1000000,
                max: 1000000,
                notEqualToZero: true
            }
            // Dodaj inne reguły walidacji dla pozostałych pól formularza, jeśli są
        },
        messages: {
            amount: {
                required: "Please enter amount.",
                number: "Please enter a valid number.",
                min: "Amount must be greater than or equal to -1 000 000.",
                max: "Amount must be less than or equal to 1 000 000.",
                notEqualToZero: "Amount cannot be zero."
            }
            // Dodaj inne komunikaty dla pozostałych pól, jeśli są
        },
        errorPlacement: function(error, element) {
            error.insertAfter(element); // Wyświetlenie komunikatów błędów po polu formularza
        }
    });

    // Dodanie nowej metody do walidacji (notEqualToZero)
    $.validator.addMethod("notEqualToZero", function(value, element) {
        return parseFloat(value) !== 0; // Sprawdzenie, czy wartość nie jest równa zero
    }, "Please enter a non-zero value");
});