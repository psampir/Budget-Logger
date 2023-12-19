// Executes the script when the DOM content is fully loaded
document.addEventListener('DOMContentLoaded', function() {
    // Get today's date and the first day of the current month
    const today = new Date();
    const firstDayOfMonth = new Date(today.getFullYear(), today.getMonth(), 1);

    // Get the input fields for start and end dates
    const startDateInput = document.getElementById('startDate');
    const endDateInput = document.getElementById('endDate');

    // Set the input field values to the formatted date strings
    startDateInput.value = formatDate(firstDayOfMonth);
    endDateInput.value = formatDate(today);

    // Function to format a given date to 'YYYY-MM-DD' format
    function formatDate(date) {
        const year = date.getFullYear();
        const month = (date.getMonth() + 1).toString().padStart(2, '0');
        const day = date.getDate().toString().padStart(2, '0');
        return `${year}-${month}-${day}`;
    }
});