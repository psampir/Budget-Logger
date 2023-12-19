// ============================= Adding validation rules

$(document).ready(function() {
    $("#transactionForm").validate({
        rules: {
            amount: {
                required: true,
                number: true,
                min: 0.01,
                max: 1000000,
            },
            time: {
                required: true
            },
            date: {
                required: true
            },
            description: {
                required: true,
                maxlength: 60
            }
        },
        messages: {
            amount: {
                required: "Please enter amount.",
                number: "Please enter a valid number.",
                min: "Amount must be greater than or equal to 0.01.",
                max: "Amount must be less than or equal to 1 000 000.",
                notEqualToZero: "Amount cannot be zero."
            },
            time: {
                required: "Please enter time."
            },
            date: {
                required: "Please enter date."
            },
            description: {
                required: "Please enter description.",
                maxlength: "Description cannot exceed 60 characters"
            }
        },
        errorPlacement: function(error, element) {
            error.insertAfter(element); // Display error message after the form element
        }
    });
});

// ============================= Setting default time & date values to now
let now = new Date();
function updateCurrentDateTime() {
// Getting the current time and date
    now = new Date();

// Formatting the date to be used in the "date" field
    const currentDate = now.toISOString().split('T')[0]; // Format YYYY-MM-DD

// Formatting the time to be used in the "time" field
    let hours = now.getHours();
    let minutes = now.getMinutes();
    
// Setting values for the "time" and "date" fields in the form
    document.getElementById('time').value = `${hours.toString().padStart(2, '0')}:${minutes.toString().padStart(2, '0')}`; // Formatting to "HH:MM" format
    document.getElementById('date').value = currentDate;
}

document.getElementById('addButton').addEventListener('click', updateCurrentDateTime);

// ============================= Changing "Category" values based on transaction type

// Get references to form elements
const transactionType = document.querySelectorAll('input[name="transactionType"]');
const categorySelect = document.getElementById('category');

// Function to update the category list based on transaction type
function updateCategories() {
    // Clear the category list
    categorySelect.innerHTML = '';

    // Define categories based on the selected transaction type
    const categories = {
        income: ['Salary', 'Freelance', 'Investments', 'Rental Income', 'Interest', 'Bonus', 'Gift', 'Sales', 'Refunds', 'Dividends', 'Awards', 'Grants', 'Royalties', 'Tips', 'Others'],
        expense: ['Groceries', 'Utilities', 'Transportation', 'Entertainment', 'Healthcare', 'Insurance', 'Education', 'Dining', 'Shopping', 'Bills', 'Travel', 'Gifts', 'Investments', 'Savings', 'Housing', 'Others']
    };

    // Get the selected transaction type
    const selectedType = [...transactionType].find(radio => radio.checked).value;

    // Add categories to the list
    categories[selectedType].forEach(category => {
        // Create an option for each category
        const option = document.createElement('option');
        option.value = category;
        option.textContent = category;
        categorySelect.appendChild(option);
    });
}

// Listen for changes in the transaction type selection
transactionType.forEach(radio => {
    radio.addEventListener('change', updateCategories);
});

// Call the function to initially load categories
updateCategories();
