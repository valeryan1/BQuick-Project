function closeAllDropdowns() {
    document.querySelectorAll('.wrapp').forEach(wrapper => {
        wrapper.classList.remove('active')
    })
    document.querySelectorAll('.option .has-sub').forEach(el => el.classList.remove('active'))
}

const hamburger = document.querySelector(".toggle-btn")
const toggler = document.querySelector("#icon")
hamburger.addEventListener("click", function () {
    document.querySelector("#sidebar").classList.toggle("expand")
    toggler.classList.toggle("bx-chevrons-right")
    toggler.classList.toggle("bx-chevrons-left")
})

function searchRFQ() {
    const input = document.getElementById("searchInput").value.toUpperCase()
    const table = document.querySelector(".table")
    const trs = table.getElementsByTagName("tr")

    for (let i = 1; i < trs.length; i++) { // Mulai dari 1 untuk skip header
        let tds = trs[i].getElementsByTagName("td")
        let rowContains = false

        for (let j = 0; j < tds.length; j++) {
            let cell = tds[j]
            if (cell) {
                let text = cell.textContent || cell.innerText
                if (text.toUpperCase().indexOf(input) > -1) {
                    rowContains = true
                    break
                }
            }
        }

        trs[i].style.display = rowContains ? "" : "none"
    }
}

// Title = Menambahkan row input pada tabel 
const addRowBtn = document.getElementById('addRowBtn')
const itemTableBody = document.getElementById('itemTableBody')

// Fungsi untuk menambah baris baru
addRowBtn.addEventListener('click', () => {
    const rowCount = itemTableBody.children.length + 1 // Hitung nomor urut

    // Buat elemen tr dan td
    const newRow = document.createElement('tr')

    newRow.innerHTML = `
        <td>${rowCount}.</td> 
        <td class="name"><input type='text' class='size form-control1'></td> 
        <td class="desc"><input type='text' class='size form-control1'></td> 
        <td class="qty"><input type='number' class='size form-control1' value="0"></td> 
        <td class="uom"><input type='text' class='size tengah form-control1'></td> 
        <td class="budget"><input type='number' class='size form-control1'></td> 
        <td class="leadtime"><input type='text' class='size tengah form-control1'></td>
        <td class="delete"><button onclick="removeRow(this)" class="btn"><i class='bx bx-trash' ></i></button>`

    // Tambahkan baris baru ke tbody
    itemTableBody.appendChild(newRow)
})

function removeRow(button) {
    const row = button.parentNode.parentNode // Dapatkan elemen tr dari tombol hapus
    itemTableBody.removeChild(row) // Hapus baris dari tbody

    // Perbarui nomor urut setelah menghapus baris
    const rows = itemTableBody.getElementsByTagName('tr')
    for (let i = 0; i < rows.length; i++) {
        rows[i].getElementsByTagName('td')[0].innerText = i + 1
    }
}

document.addEventListener("DOMContentLoaded", () => {
    function sortTableByColumn(table, column, asc = true) {
        const dirModifier = asc ? 1 : -1
        const tBody = table.tBodies[0]
        const rows = Array.from(tBody.querySelectorAll("tr"))

        const sortedRows = rows.sort((a, b) => {
            const aText = a.querySelector(`td:nth-child(${column + 1})`).textContent.trim()
            const bText = b.querySelector(`td:nth-child(${column + 1})`).textContent.trim()

            const aVal = isNaN(aText) ? aText.toLowerCase() : parseFloat(aText)
            const bVal = isNaN(bText) ? bText.toLowerCase() : parseFloat(bText)

            if (aVal < bVal) return -1 * dirModifier
            if (aVal > bVal) return 1 * dirModifier
            return 0
        })

        while (tBody.firstChild) {
            tBody.removeChild(tBody.firstChild)
        }

        tBody.append(...sortedRows)

        table.querySelectorAll("th").forEach(th =>
            th.classList.remove("th-sort-asc", "th-sort-desc")
        )
        const th = table.querySelector(`th:nth-child(${column + 1})`)
        th.classList.toggle("th-sort-asc", asc)
        th.classList.toggle("th-sort-desc", !asc)
    }

    document.querySelectorAll(".table-sortable th").forEach(headerCell => {
        headerCell.addEventListener("click", () => {
            const table = headerCell.closest("table")
            const headerIndex = Array.from(headerCell.parentElement.children).indexOf(headerCell)
            const currentIsAscending = headerCell.classList.contains("th-sort-asc")

            sortTableByColumn(table, headerIndex, !currentIsAscending)
        })
    })
})

document.querySelectorAll(".add-customer-form-close-btn").forEach(btn => {
    btn.addEventListener("click", function () {
        document.querySelector(".add-customer-form-pop-up").classList.remove("active")
        document.body.classList.remove("pop-up-active")
    })
})

function getCompanyCode(name) {
    return name
        .split(/\s+/)
        .map(w => w[0])
        .filter(Boolean)
        .join('')
        .toUpperCase()
}

document.querySelectorAll(".add-customer-form-save-btn").forEach(btn => {
    btn.addEventListener("click", function (e) {
        e.preventDefault()

        const modal = document.querySelector(".add-customer-form-pop-up")
        const companyNameInput = modal.querySelector('input[placeholder="Company Name"]')
        const companyName = companyNameInput ? companyNameInput.value.trim() : ""

        if (!companyName) {
            modal.classList.remove("active")
            document.body.classList.remove("pop-up-active")
            return
        }

        modal.classList.remove("active")
        document.body.classList.remove("pop-up-active")

        const companyWrapper = document.querySelector(".wrapp.company-dropdown")
        const companySelectBtn = companyWrapper.querySelector(".select-btn")
        const companySearchInp = companyWrapper.querySelector("input")
        const companyOptions = companyWrapper.querySelector(".option")

        if (!companies.includes(companyName)) {
            companies.unshift(companyName)
        }

        const code = getCompanyCode(companyName)
        companySelectBtn.firstElementChild.innerText = code ? `${companyName} (${code})` : companyName
        companySearchInp.value = ""
        addCompany(companyName)
        companyWrapper.classList.remove("active")
    })
})

var customerAddressDetailsCheckbox = document.querySelector("#customer-address-details-checkbox")
if (customerAddressDetailsCheckbox) {
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
}

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

// Title = Search Company name
const companyWrapper = document.querySelector(".wrapp.company-dropdown"),
    companySelectBtn = companyWrapper.querySelector(".select-btn"),
    companySearchInp = companyWrapper.querySelector("input"),
    companyOptions = companyWrapper.querySelector(".option")

let companies = [
    "PT. Accenture",
    "PT. Adhya Tirta Batam",
    "PT. Agiva Indonesia",
    "PT. Pelangi Fortuna Global",
    "PT. Indoshipsupply",
    "PT. Bintan Sukses Ancol",
    "PT. Citra Maritime",
    "PT. Bintai Kindenko Engineering Indonesia",
    "PT. Karya Abadi",
    "PT. Digital Solutions",
    "PT. Nusantara Shipping",
    "PT. Mandiri Sejahtera",
    "PT. Pertiwi",
    "PT. Megah",
    "PT. Maju Sejahtera",
    "PT. Harmoni",
    "PT. Prima",
    "PT. Sentosa",
    "PT. Nusantara",
    "PT. Satu",
    "PT. Global Investama",
    "PT. Intertech",
    "PT. Jaya Abadi"
]

function addCompany(selectedCompany) {
    companyOptions.innerHTML = ""
    companies.forEach(Company => {
        let isSelected = Company == selectedCompany ? "selected" : ""
        let li = `<li onclick="updateName(this)" class="${isSelected}">${Company}</li>`
        companyOptions.insertAdjacentHTML("beforeend", li)
    })
}
addCompany()

function updateName(selectedLi) {
    companySearchInp.value = ""
    addCompany(selectedLi.innerText)
    companyWrapper.classList.remove("active")
    const code = getCompanyCode(selectedLi.innerText)
    companySelectBtn.firstElementChild.innerText = code ? `${selectedLi.innerText} (${code})` : selectedLi.innerText
}

function createCompanyOption(name) {
    companyWrapper.classList.remove("active")
    companySearchInp.value = ""
    addCompany(name)

    const modal = document.querySelector(".add-customer-form-pop-up")
    modal.classList.add("active")
    document.body.classList.add("pop-up-active")

    const companyNameInput = modal.querySelector('input[placeholder="Company Name"]')
    if (companyNameInput) {
        companyNameInput.value = name
    }
}

companySearchInp.addEventListener("keyup", () => {
    let searchWord = companySearchInp.value.trim()
    let arr = companies.filter(data => {
        return data.toLowerCase().includes(searchWord.toLowerCase())
    }).map(data => {
        let isSelected = data == companySelectBtn.firstElementChild.innerText ? "selected" : ""
        return `<li onclick="updateName(this)" class="${isSelected}">${data}</li>`
    })

    if (searchWord.length > 0) {
        arr.unshift(`<li class="create-option"onclick="createCompanyOption('${searchWord}')">Create "${searchWord}"</li>`)
    }

    companyOptions.innerHTML = arr.length > 0 ? arr.join("") : `<p style="margin-top: 10px;">Oops! Company not found</p>`
})

companySelectBtn.addEventListener("click", function (e) {
    e.stopPropagation()
    const isActive = companyWrapper.classList.contains("active")
    closeAllDropdowns()
    if (!isActive) {
        companyWrapper.classList.add("active")
    }
})

companySearchInp.addEventListener("click", function (e) {
    e.stopPropagation()
})

const resourceWrapper = document.querySelector('.wrapp.resource-dropdown')
const resourceSelectBtn = resourceWrapper.querySelector('.select-btn')
const resourceOptions = resourceWrapper.querySelectorAll('.option > li:not(.has-sub)')
const personalOption = document.getElementById('resource-personal-option')
const personalSubDropdown = document.getElementById('resource-personal-sub-dropdown')

resourceSelectBtn.addEventListener("click", function (e) {
    e.stopPropagation()
    const isActive = resourceWrapper.classList.contains("active")
    closeAllDropdowns()
    if (!isActive) {
        resourceWrapper.classList.add("active")
    }
})

resourceOptions.forEach(option => {
    option.addEventListener('click', function (e) {
        e.stopPropagation()
        resourceSelectBtn.firstElementChild.innerText = this.innerText
        resourceWrapper.classList.remove("active")
        document.querySelectorAll('.option .has-sub').forEach(el => el.classList.remove('active'))
    })
})

personalOption.addEventListener('click', function (e) {
    e.stopPropagation()
    document.querySelectorAll('.option > .has-sub').forEach(li => {
        if (li !== personalOption) li.classList.remove('active')
    })
    personalOption.classList.toggle('active')
})

document.querySelectorAll('#resource-personal-sub-dropdown > .has-sub').forEach(parent => {
    parent.addEventListener('click', function (e) {
        e.stopPropagation()
        document.querySelectorAll('#resource-personal-sub-dropdown > .has-sub').forEach(li => {
            if (li !== this) li.classList.remove('active')
        })
        this.classList.toggle('active')
    })
})

function updateResourcePersonalUser(selectedLi) {
    const parentType = selectedLi.parentElement.parentElement.firstChild.textContent.trim()
    const user = selectedLi.textContent.trim()
    resourceSelectBtn.firstElementChild.innerText = `Personal ${parentType} (${user})`
    resourceWrapper.classList.remove("active")
    document.querySelectorAll('.option .has-sub').forEach(el => el.classList.remove('active'))
}

const projectTypeWrapper = document.querySelector('.wrapp.project-type-dropdown')
const projectTypeSelectBtn = projectTypeWrapper.querySelector('.select-btn')
const projectTypeOptions = projectTypeWrapper.querySelectorAll('.option li')

projectTypeSelectBtn.addEventListener("click", function (e) {
    e.stopPropagation()
    const isActive = projectTypeWrapper.classList.contains("active")
    closeAllDropdowns()
    if (!isActive) {
        projectTypeWrapper.classList.add("active")
    }
})

projectTypeOptions.forEach(option => {
    option.addEventListener('click', function (e) {
        e.stopPropagation()
        projectTypeSelectBtn.firstElementChild.innerText = this.innerText
        projectTypeWrapper.classList.remove("active")
    })
})

const opportunityWrapper = document.getElementById('opportunity-dropdown')
const opportunitySelectBtn = opportunityWrapper.querySelector('.select-btn')
const opportunityOptions = opportunityWrapper.querySelectorAll('.option li')

opportunitySelectBtn.addEventListener("click", function (e) {
    e.stopPropagation()
    const isActive = opportunityWrapper.classList.contains("active")
    closeAllDropdowns()
    if (!isActive) {
        opportunityWrapper.classList.add("active")
    }
})

opportunityOptions.forEach(option => {
    option.addEventListener('click', function (e) {
        e.stopPropagation()
        opportunitySelectBtn.firstElementChild.innerText = this.innerText
        opportunityWrapper.classList.remove("active")
    })
})

document.addEventListener('click', function (e) {
    document.querySelectorAll('.wrapp').forEach(wrapper => {
        wrapper.classList.remove('active')
    })
    document.querySelectorAll('.option .has-sub').forEach(el => el.classList.remove('active'))
})

document.addEventListener("DOMContentLoaded", function () {
    const requestDateInput = document.getElementById('request-date')
    const dueDateInput = document.getElementById('due-date')

    requestDateInput.addEventListener('change', function () {
        const requestDateValue = this.value
        if (requestDateValue) {
            const requestDate = new Date(requestDateValue)
            requestDate.setDate(requestDate.getDate() + 2)

            const year = requestDate.getFullYear()
            const month = String(requestDate.getMonth() + 1).padStart(2, '0')
            const day = String(requestDate.getDate()).padStart(2, '0')
            const dueDateValue = `${year}-${month}-${day}`

            dueDateInput.value = dueDateValue
        } else {
            dueDateInput.value = ''
        }
    })
})

let uploadedFiles = []
const form = document.querySelector('.form-upload'),
    fileInput = document.querySelector(".file-input"),
    attachedFilesContainer = document.getElementById('attached-files'),
    uploadedArea = document.querySelector(".uploaded-area"),
    attachmentCount = document.querySelector('.attachment-count')

form.addEventListener("click", () => {
    fileInput.click()
})

let nameOfFile
fileInput.onchange = ({ target }) => {
    let file = target.files[0]
    if (file) {
        let fileName = file.name
        if (fileName.length >= 20) {
            let splitName = fileName.split('.')
            fileName = splitName[0].substring(0, 21) + "... ." + splitName[1]
        }
        nameOfFile = fileName
    }
}

function createFileInfo(file) {
    let iconClass = 'fas fa-file'
    if (file.type.startsWith('image/')) {
        iconClass = 'fas fa-file-image'
    } else if (file.type.startsWith('application/pdf')) {
        iconClass = 'fas fa-file-pdf'
    } else if (file.type.startsWith('application/msword') || file.type.startsWith('application/vnd.openxmlformats-officedocument.wordprocessingml.document')) {
        iconClass = 'fas fa-file-word'
    }

    let fileTotal = Math.floor(file.size / 1024)
    let fileSize
    (fileTotal < 1000) ? fileSize = fileTotal + " KB" : fileSize = (file.size / (1024 * 1024)).toFixed(2) + " MB"
    const fileInfo = document.createElement('div')
    fileInfo.classList.add('row')
    fileInfo.innerHTML = `
                <div class="content upload">
                                  <i class="${iconClass}"></i>
                                  <div class="details">
                                    <span class="name">${nameOfFile}</span>
                                    <span class="size">${fileSize}</span>
                                  </div>
                                  <div class="button-function">
                                    <button class="delete-button float-end me-1"><i class="fas fa-times"></i></button>
                                    <button class="download-button float-end me-1"><i class="fas fa-download"></i></button> 
                                  </div>
                                </div>
            `

    const downloadBtn = fileInfo.querySelector('.download-button')
    downloadBtn.addEventListener('click', () => {
        const url = URL.createObjectURL(file)
        const a = document.createElement('a')
        a.href = url
        a.download = file.name
        document.body.appendChild(a)
        a.click()
        document.body.removeChild(a)
        URL.revokeObjectURL(url)
    })

    const deleteBtn = fileInfo.querySelector('.delete-button')
    deleteBtn.addEventListener('click', () => {
        const fileIndex = uploadedFiles.indexOf(file)
        if (fileIndex > -1) {
            uploadedFiles.splice(fileIndex, 1)
        }
        attachedFilesContainer.removeChild(fileInfo)
        updateCount()
    })

    return fileInfo
}

function updateCount() {
    attachmentCount.textContent = uploadedFiles.length
    if (uploadedFiles.length > 0) {
        attachedFilesContainer.style.display = 'block'
    } else {
        attachedFilesContainer.style.display = 'none'
    }
}

fileInput.addEventListener('change', () => {
    const currentCount = uploadedFiles.length
    if (currentCount >= 5) {
        alert('Maksimum 5 berkas diperbolehkan.')
        return
    }
    const newFiles = Array.from(fileInput.files)
    const maxToAdd = 5 - currentCount
    const filesToAdd = newFiles.slice(0, maxToAdd)
    if (filesToAdd.length < newFiles.length) {
        alert(`Hanya ${maxToAdd} berkas lagi yang dapat ditambahkan. ${maxToAdd} berkas pertama akan ditambahkan.`)
    }
    filesToAdd.forEach((file) => {
        uploadedFiles.push(file)
        const fileInfo = createFileInfo(file)
        attachedFilesContainer.appendChild(fileInfo)
    })
    updateCount()
    fileInput.value = ''
})

// Title = Menambahkan row input pada tabel
const addRowBtnItem = document.getElementById('addRowBtnItem')
const itemlistTableBody = document.getElementById('itemListTableBody')

// Fungsi untuk menambah baris baru
addRowBtnItem.addEventListener('click', () => {
    const rowCount2 = itemListTableBody.children.length + 1 // Hitung nomor urut

    // Buat elemen tr dan td
    const newRow = document.createElement('tr')

    newRow.innerHTML = `
                        <td>${rowCount2}</td> 
                        <td class="name"><input type='text' class='size form-control1'></td>
                        <td class="desc"><input type='text' class='size form-control1'></td>
                        <td class="qty"><input type='number' class='size form-control1' value="0"></td>
                        <td class="uom"><input type='text' class='size tengah form-control1'></td>
						<td class="price"><input type='number' class='size form-control1'></td>
						<td class="notes"><input type='text' class='size form-control1'></td>
						<td class="details"><input type='text' class='size form-control1'></td>
						<td class="warranty"><input type='text' class='size form-control1'></td>
						<td class="amount"><input type='number' class='size form-control1'></td>
                        <td class="delete"><button onclick="removeRowItemList(this)" class="btn"><i class='bx bx-trash'></i></button>`

    // Tambahkan baris baru ke tbody
    itemListTableBody.appendChild(newRow)
})

function removeRowItemList(button) {
    const row = button.parentNode.parentNode // Dapatkan elemen tr dari tombol hapus
    itemListTableBody.removeChild(row) // Hapus baris dari tbody

    // Perbarui nomor urut setelah menghapus baris
    const rows = itemListTableBody.getElementsByTagName('tr')
    for (let i = 0; i < rows.length; i++) {
        rows[i].getElementsByTagName('td')[0].innerText = i + 1
    }
}

// Title = Menambahkan row input pada tabel Request
const addRowBtnReq = document.getElementById('addRowBtnReq')
const reqTableBody = document.getElementById('reqTableBody')

// Fungsi untuk menambah baris baru
addRowBtnReq.addEventListener('click', () => {
    const rowCount2 = reqTableBody.children.length + 1 // Hitung nomor urut

    // Buat elemen tr dan td
    const newRow = document.createElement('tr')

    newRow.innerHTML = `
                            <td class="action"><button onclick="" class="btn"><i class='bx bx-plus-circle'></i></button></td>
                            <td class="nomor" style="padding: 14px 9px;">${rowCount2}</td>
                            <td class="reqCode"><input type='text' class='tengah size form-control1'></td>
                            <td class="name"><input type='text' class='size form-control1'></td>
                            <td class="desc"><input type='text' class='size form-control1'></td>
                            <td class="qty"><input type='number' class='size form-control1' value="0"></td>
                            <td class="uom"><input type='text' class='size tengah form-control1'></td>
							<td class="reason"><input type='text' class='size form-control1'></td>
							<td class="notes"><input type='text' class='size form-control1'></td>
							<td class="pic"><input type='text' class='size form-control1'></td>
							<td class="status"><input type='text' class='size form-control1'></td>

                            <td class="delete"><button onclick="removeRowReq(this)" class="btn"><i class='bx bx-trash'></i></button></td>`

    // Tambahkan baris baru ke tbody
    reqTableBody.appendChild(newRow)
})

function removeRowReq(button) {
    const row = button.parentNode.parentNode // Dapatkan elemen tr dari tombol hapus
    reqTableBody.removeChild(row) // Hapus baris dari tbody

    // Perbarui nomor urut setelah menghapus baris
    const rows = reqTableBody.getElementsByTagName('tr')
    for (let i = 0; i < rows.length; i++) {
        rows[i].getElementsByTagName('td')[1].innerText = i + 1
    }
}

document.querySelector("#request-item-to-purchasing-option").addEventListener("click", function () {
    const modal = document.querySelector(".request-item-to-purchasing-form-pop-up")
    modal.classList.add("active")
    document.body.classList.add("pop-up-active")
    
    modal.scrollTop = 0
})

document.querySelector(".request-item-to-purchasing-form-close-btn").addEventListener("click", function () {
    document.querySelector(".request-item-to-purchasing-form-pop-up").classList.remove("active")
    document.body.classList.remove("pop-up-active")
})

document.querySelector(".request-item-to-purchasing-form-cancel-btn").addEventListener("click", function () {
    document.querySelector(".request-item-to-purchasing-form-pop-up").classList.remove("active")
    document.body.classList.remove("pop-up-active")
})
