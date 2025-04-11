// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const hamburger = document.querySelector(".toggle-btn")
const toggler = document.querySelector("#icon")
hamburger.addEventListener("click", function () {
    document.querySelector("#sidebar").classList.toggle("expand");
    toggler.classList.toggle("bx-chevrons-right")
    toggler.classList.toggle("bx-chevrons-left")
})

document.querySelector("#create-customer-option").addEventListener("click", function () {
    document.querySelector(".add-customer-form-pop-up").classList.add("active")
    document.body.classList.add("popup-active")
})

document.querySelector(".add-customer-form-close-btn").addEventListener("click", function () {
    document.querySelector(".add-customer-form-pop-up").classList.remove("active")
    document.body.classList.remove("popup-active")
})

var customerAddressDetailsCheckbox = document.querySelector("#customer-address-details-checkbox")
customerAddressDetailsCheckbox.addEventListener("change", function () {
    const customerAddressDetails = document.querySelectorAll(".customer-address-details");

    if (this.checked) {
        customerAddressDetails.forEach(element => {
            element.classList.add("active")
        });
    } else {
        customerAddressDetails.forEach(element => {
            element.classList.remove("active")
        })
    }
})

var matchCustomerBillingAddressCheckbox = document.getElementById("match-customer-billing-address-checkbox");
var customerBillingAddressFields = [
    "address", "street", "city", "province", "country", "zip-code"
]
function updateCustomerShippingAddress() {
    if (matchCustomerBillingAddressCheckbox.checked) {
        customerBillingAddressFields.forEach(field => {
            var customerBillingAddressValue = document.getElementById("customer-billing-${field}").value
            document.getElementById("customer-shipping-${field}").value = customerBillingAddressValue
        })
    }
}
matchCustomerBillingAddressCheckbox.addEventListener("change", function () {
    if (this.checked) {
        updateCustomerShippingAddress()
        customerBillingAddressFields.forEach(field => {
            document.getElementById("customer-shipping-${field}").disabled = true
        })
    } else {
        customerBillingAddressFields.forEach(field => {
            document.getElementById("customer-shipping-${field}").disabled = false
        })
    }
});
customerBillingAddressFields.forEach(field => {
    document.getElementById("customer-billing-${field}").addEventListener("input", updateCustomerShippingAddress);
});
