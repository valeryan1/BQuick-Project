const hamburger = document.querySelector(".toggle-btn")
const toggler = document.querySelector("#icon")
hamburger.addEventListener("click", function () {
    document.querySelector("#sidebar").classList.toggle("expand")
    toggler.classList.toggle("bx-chevrons-right")
    toggler.classList.toggle("bx-chevrons-left")
})

function searchRFQ() {
    const input = document.getElementById("searchInput").value.toUpperCase();
    const table = document.querySelector(".table");
    const trs = table.getElementsByTagName("tr");

    for (let i = 1; i < trs.length; i++) { // Mulai dari 1 untuk skip header
        let tds = trs[i].getElementsByTagName("td");
        let rowContains = false;

        for (let j = 0; j < tds.length; j++) {
            let cell = tds[j];
            if (cell) {
                let text = cell.textContent || cell.innerText;
                if (text.toUpperCase().indexOf(input) > -1) {
                    rowContains = true;
                    break;
                }
            }
        }

        trs[i].style.display = rowContains ? "" : "none";
    }
}

document.querySelector("#create-customer-option").addEventListener("click", function () {
    document.querySelector(".add-customer-form-pop-up").classList.add("active")
    document.body.classList.add("pop-up-active")
})

document.querySelector(".add-customer-form-close-btn").addEventListener("click", function () {
    document.querySelector(".add-customer-form-pop-up").classList.remove("active")
    document.body.classList.remove("pop-up-active")
})

var customerAddressDetailsCheckbox = document.querySelector("#customer-address-details-checkbox")
customerAddressDetailsCheckbox.addEventListener("change", function () {
    const customerAddressDetails = document.querySelectorAll(".customer-address-details")

    if (this.checked) {
        customerAddressDetails.forEach(element => {
            element.classList.add("active")
        })
    } else {
        customerAddressDetails.forEach(element => {
            element.classList.remove("active")
        })
    }
})

var matchCustomerBillingAddressCheckbox = document.getElementById("match-customer-billing-address-checkbox")
var customerAddressFields = [
    "address", "street", "city", "province", "country", "zip-code"
]

function updateCustomerShippingAddress() {
    if (matchCustomerBillingAddressCheckbox.checked) {
        customerAddressFields.forEach(field => {
            var customerBillingAddressValue = document.getElementById(`customer-billing-${field}`).value
            document.getElementById(`customer-shipping-${field}`).value = customerBillingAddressValue
        })
    }
}

matchCustomerBillingAddressCheckbox.addEventListener("change", function () {
    if (this.checked) {
        updateCustomerShippingAddress()
        customerAddressFields.forEach(field => {
            document.getElementById(`customer-shipping-${field}`).disabled = true
        })
    } else {
        customerAddressFields.forEach(field => {
            document.getElementById(`customer-shipping-${field}`).disabled = false
        })
    }
})

customerAddressFields.forEach(field => {
    document.getElementById(`customer-billing-${field}`).addEventListener("input", updateCustomerShippingAddress)
})

const customerContactRoleButtons = document.querySelectorAll(".customer-contact-role-btn")
const customerEndUserContactButton = document.getElementById("customer-end-user-contact-btn")

function setActiveCustomerContactRoleButton(activeCustomerContactRoleButton) {
    customerContactRoleButtons.forEach(button => {
        button.style.border = "1px solid #afafaf"
        button.style.color = "#b0b0b0"
        button.style.fontWeight = "normal"
    })

    activeCustomerContactRoleButton.style.border = "2px solid #000"
    activeCustomerContactRoleButton.style.color = "#000"
    activeCustomerContactRoleButton.style.fontWeight = "500"
}

document.addEventListener("DOMContentLoaded", function () {
    setActiveCustomerContactRoleButton(customerEndUserContactButton)

    const customerContactRoleValue = customerEndUserContactButton.getAttribute("value")
    document.getElementById("customer-contact-role-information-title").textContent = customerContactRoleValue

    document.querySelector("#customer-contact-form-open-chevron").classList.add("hide")
    document.querySelector("#customer-contact-form-close-chevron").classList.remove("hide")


    document.querySelector(".show-customer-contact-form-pop-up").classList.add("active")
})

customerContactRoleButtons.forEach(button => {
    button.addEventListener("click", function () {
        setActiveCustomerContactRoleButton(this)

        const customerContactRoleValue = this.getAttribute("value")
        document.getElementById("customer-contact-role-information-title").textContent = customerContactRoleValue
    })
})

document.querySelector("#add-customer-contact-btn").addEventListener("click", function () {
    document.querySelector(".add-customer-contact-form-pop-up").classList.add("active")
    document.querySelector(".add-customer-contact-btn-container").classList.add("hide")
})

document.querySelector(".add-customer-contact-form-close-btn").addEventListener("click", function () {
    document.querySelector(".add-customer-contact-form-pop-up").classList.remove("active")
    document.querySelector(".add-customer-contact-btn-container").classList.remove("hide")
})

document.querySelector("#customer-contact-form-open-chevron").addEventListener("click", function () {
    document.querySelector("#customer-contact-form-open-chevron").classList.add("hide")
    document.querySelector("#customer-contact-form-close-chevron").classList.remove("hide")

    document.querySelector(".show-customer-contact-form-pop-up").classList.add("active")
})

document.querySelector("#customer-contact-form-close-chevron").addEventListener("click", function () {
    document.querySelector("#customer-contact-form-close-chevron").classList.add("hide")
    document.querySelector("#customer-contact-form-open-chevron").classList.remove("hide")

    document.querySelector(".show-customer-contact-form-pop-up").classList.remove("active")
})
