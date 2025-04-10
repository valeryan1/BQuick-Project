// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const hamburger = document.querySelector(".toggle-btn");
const toggler = document.querySelector("#icon");
hamburger.addEventListener("click", function () {
    document.querySelector("#sidebar").classList.toggle("expand");
    toggler.classList.toggle("bx-chevrons-right");
    toggler.classList.toggle("bx-chevrons-left");
})

document.querySelector("#create-customer-option").addEventListener("click", function () {
    document.querySelector(".add-customer-form-pop-up").classList.add("active")
    document.body.classList.add("popup-active")
})

document.querySelector(".add-customer-form-close-btn").addEventListener("click", function () {
    document.querySelector(".add-customer-form-pop-up").classList.remove("active")
    document.body.classList.remove("popup-active")
})

