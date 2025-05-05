// =======================
// Helper Functions
// =======================

// Tutup semua dropdown custom
function closeAllDropdowns() {
    document.querySelectorAll('.wrapp').forEach(wrapper => {
        wrapper.classList.remove('active');
    });
    document.querySelectorAll('.option .has-sub').forEach(el => el.classList.remove('active'));
}

// Untuk generate kode perusahaan dari nama
function getCompanyCode(name) {
    return name
        .split(/\s+/)
        .map(w => w[0])
        .filter(Boolean)
        .join('')
        .toUpperCase();
}

// =======================
// DOMContentLoaded Wrapper
// =======================
document.addEventListener("DOMContentLoaded", function () {

    // =======================
    // Sidebar Toggle
    // =======================
    const hamburger = document.querySelector(".toggle-btn");
    const toggler = document.querySelector("#icon");
    if (hamburger && toggler) {
        hamburger.addEventListener("click", function () {
            document.querySelector("#sidebar").classList.toggle("expand");
            toggler.classList.toggle("bx-chevrons-right");
            toggler.classList.toggle("bx-chevrons-left");
        });
    }

    // =======================
    // Add Customer Form Popup
    // =======================
    const addBtn = document.getElementById('add-customer-contact-btn');
    const formPopUp = document.querySelector('.add-customer-contact-form-pop-up');
    const closeChevron = document.getElementById('customer-contact-form-open-chevron');

    // Awal: form pop-up disembunyikan, tombol Add tampil
    if (formPopUp) formPopUp.style.display = 'none';
    if (addBtn) addBtn.style.display = 'block';

    // Saat tombol Add diklik: tampilkan form pop-up, tombol Add hilang
    if (addBtn && formPopUp) {
        addBtn.addEventListener('click', function () {
            formPopUp.style.display = 'block';
            addBtn.style.display = 'none';
        });
    }

    // Saat Chevron diklik: sembunyikan form pop-up, tombol Add tampil lagi
    if (closeChevron && formPopUp && addBtn) {
        closeChevron.addEventListener('click', function () {
            formPopUp.style.display = 'none';
            addBtn.style.display = 'block';
        });
    }

    const infoPopUp = document.querySelector('.show-customer-contact-information-form-pop-up');
    const closeBtn = document.getElementById('customer-contact-information-form-open-minus');
    const openChevron = document.getElementById('customer-contact-information-form-close-chevron');

    // By default, tampilkan pop-up dan sembunyikan chevron open
    if (infoPopUp) infoPopUp.classList.add('active');
    if (openChevron) openChevron.style.display = 'none';

    // Saat klik minus, sembunyikan pop-up dan tampilkan chevron open
    if (closeBtn && infoPopUp && openChevron) {
        closeBtn.addEventListener('click', function () {
            infoPopUp.classList.remove('active');
            openChevron.style.display = 'inline-block';
        });
    }

    // Saat klik chevron open, tampilkan pop-up dan sembunyikan chevron open
    if (openChevron && infoPopUp) {
        openChevron.addEventListener('click', function () {
            infoPopUp.classList.add('active');
            openChevron.style.display = 'none';
        });
    }

    document.querySelectorAll(".add-customer-form-close-btn").forEach(btn => {
        btn.addEventListener("click", function () {
            const modal = document.querySelector(".add-customer-form-pop-up");
            if (modal) modal.classList.remove("active");
            document.body.classList.remove("pop-up-active");
        });
    });

    document.querySelectorAll(".add-customer-form-save-btn").forEach(btn => {
        btn.addEventListener("click", function (e) {
            e.preventDefault();
            const modal = document.querySelector(".add-customer-form-pop-up");
            if (!modal) return;
            const companyNameInput = modal.querySelector('input[placeholder="Company Name"]');
            const companyName = companyNameInput ? companyNameInput.value.trim() : "";
            if (!companyName) {
                modal.classList.remove("active");
                document.body.classList.remove("pop-up-active");
                return;
            }
            modal.classList.remove("active");
            document.body.classList.remove("pop-up-active");
            // Update dropdown company
            if (window.companies && window.addCompany && window.companyWrapper) {
                if (!companies.includes(companyName)) {
                    companies.unshift(companyName);
                }
                const code = getCompanyCode(companyName);
                companyWrapper.querySelector(".select-btn").firstElementChild.innerText = code ? `${companyName} (${code})` : companyName;
                companyWrapper.querySelector("input").value = "";
                addCompany(companyName);
                companyWrapper.classList.remove("active");
            }
        });
    });

    // =======================
    // Address Checkbox Logic
    // =======================
    const customerAddressDetailsCheckbox = document.querySelector("#customer-address-details-checkbox");
    if (customerAddressDetailsCheckbox) {
        customerAddressDetailsCheckbox.addEventListener("change", function () {
            const details = document.querySelectorAll(".customer-address-details");
            details.forEach(element => {
                if (this.checked) {
                    element.classList.add("active");
                } else {
                    element.classList.remove("active");
                }
            });
        });
    }

    // Checkbox "Same With Billing Address"
    const matchCustomerBillingAddressCheckbox = document.getElementById("match-customer-billing-address-checkbox");
    const customerAddressFields = [
        "address", "street", "city", "province", "country", "zip-code"
    ];

    function updateCustomerShippingAddress() {
        if (!matchCustomerBillingAddressCheckbox) return;
        if (matchCustomerBillingAddressCheckbox.checked) {
            customerAddressFields.forEach(field => {
                const billing = document.getElementById(`customer-billing-${field}`);
                const shipping = document.getElementById(`customer-shipping-${field}`);
                if (billing && shipping) {
                    shipping.value = billing.value;
                }
            });
        }
    }

    if (matchCustomerBillingAddressCheckbox) {
        matchCustomerBillingAddressCheckbox.addEventListener("change", function () {
            customerAddressFields.forEach(field => {
                const shipping = document.getElementById(`customer-shipping-${field}`);
                if (shipping) {
                    shipping.disabled = this.checked;
                }
            });
            if (this.checked) updateCustomerShippingAddress();
        });

        customerAddressFields.forEach(field => {
            const billing = document.getElementById(`customer-billing-${field}`);
            if (billing) billing.addEventListener("input", updateCustomerShippingAddress);
        });
    }

    // =======================
    // Custom Dropdown Company
    // =======================
    window.companyWrapper = document.querySelector(".wrapp.company-dropdown");
    if (companyWrapper) {
        const companySelectBtn = companyWrapper.querySelector(".select-btn");
        const companySearchInp = companyWrapper.querySelector("input");
        const companyOptions = companyWrapper.querySelector(".option");

        window.companies = [
            "PT. Accenture", "PT. Adhya Tirta Batam", "PT. Agiva Indonesia", "PT. Pelangi Fortuna Global",
            "PT. Indoshipsupply", "PT. Bintan Sukses Ancol", "PT. Citra Maritime", "PT. Bintai Kindenko Engineering Indonesia",
            "PT. Karya Abadi", "PT. Digital Solutions", "PT. Nusantara Shipping", "PT. Mandiri Sejahtera", "PT. Pertiwi",
            "PT. Megah", "PT. Maju Sejahtera", "PT. Harmoni", "PT. Prima", "PT. Sentosa", "PT. Nusantara",
            "PT. Satu", "PT. Global Investama", "PT. Intertech", "PT. Jaya Abadi"
        ];

        window.addCompany = function (selectedCompany) {
            companyOptions.innerHTML = "";
            companies.forEach(Company => {
                let isSelected = Company == selectedCompany ? "selected" : "";
                let li = document.createElement("li");
                li.textContent = Company;
                li.className = isSelected;
                li.onclick = function () { updateName(this); };
                companyOptions.appendChild(li);
            });
        };

        function updateName(selectedLi) {
            companySearchInp.value = "";
            addCompany(selectedLi.textContent);
            companyWrapper.classList.remove("active");
            const code = getCompanyCode(selectedLi.textContent);
            companySelectBtn.firstElementChild.innerText = code ? `${selectedLi.textContent} (${code})` : selectedLi.textContent;
        }

        function createCompanyOption(name) {
            companyWrapper.classList.remove("active");
            companySearchInp.value = "";
            addCompany(name);
            const modal = document.querySelector(".add-customer-form-pop-up");
            if (modal) {
                modal.classList.add("active");
                document.body.classList.add("pop-up-active");
                const companyNameInput = modal.querySelector('input[placeholder="Company Name"]');
                if (companyNameInput) companyNameInput.value = name;
            }
        }

        addCompany();

        companySearchInp.addEventListener("keyup", () => {
            let searchWord = companySearchInp.value.trim();
            let arr = companies.filter(data => {
                return data.toLowerCase().includes(searchWord.toLowerCase());
            }).map(data => {
                let isSelected = data == companySelectBtn.firstElementChild.innerText ? "selected" : "";
                let li = document.createElement("li");
                li.textContent = data;
                li.className = isSelected;
                li.onclick = function () { updateName(this); };
                return li;
            });

            companyOptions.innerHTML = "";
            if (searchWord.length > 0) {
                let createLi = document.createElement("li");
                createLi.className = "create-option";
                createLi.textContent = `Create "${searchWord}"`;
                createLi.onclick = function () { createCompanyOption(searchWord); };
                companyOptions.appendChild(createLi);
            }
            if (arr.length > 0) {
                arr.forEach(li => companyOptions.appendChild(li));
            } else {
                let p = document.createElement("p");
                p.style.marginTop = "10px";
                p.textContent = "Oops! Company not found";
                companyOptions.appendChild(p);
            }
        });

        companySelectBtn.addEventListener("click", function (e) {
            e.stopPropagation();
            const isActive = companyWrapper.classList.contains("active");
            closeAllDropdowns();
            if (!isActive) companyWrapper.classList.add("active");
        });

        companySearchInp.addEventListener("click", function (e) {
            e.stopPropagation();
        });
    }

    // =======================
    // Custom Dropdown Resource
    // =======================
    const resourceWrapper = document.querySelector('.wrapp.resource-dropdown');
    if (resourceWrapper) {
        const resourceSelectBtn = resourceWrapper.querySelector('.select-btn');
        const resourceOptions = resourceWrapper.querySelectorAll('.option > li:not(.has-sub)');
        const personalOption = document.getElementById('resource-personal-option');
        const personalSubDropdown = document.getElementById('resource-personal-sub-dropdown');

        if (resourceSelectBtn) {
            resourceSelectBtn.addEventListener("click", function (e) {
                e.stopPropagation();
                const isActive = resourceWrapper.classList.contains("active");
                closeAllDropdowns();
                if (!isActive) resourceWrapper.classList.add("active");
            });
        }

        resourceOptions.forEach(option => {
            option.addEventListener('click', function (e) {
                e.stopPropagation();
                resourceSelectBtn.firstElementChild.innerText = this.innerText;
                resourceWrapper.classList.remove("active");
                document.querySelectorAll('.option .has-sub').forEach(el => el.classList.remove('active'));
            });
        });

        if (personalOption) {
            personalOption.addEventListener('click', function (e) {
                e.stopPropagation();
                document.querySelectorAll('.option > .has-sub').forEach(li => {
                    if (li !== personalOption) li.classList.remove('active');
                });
                personalOption.classList.toggle('active');
            });
        }

        document.querySelectorAll('#resource-personal-sub-dropdown > .has-sub').forEach(parent => {
            parent.addEventListener('click', function (e) {
                e.stopPropagation();
                document.querySelectorAll('#resource-personal-sub-dropdown > .has-sub').forEach(li => {
                    if (li !== this) li.classList.remove('active');
                });
                this.classList.toggle('active');
            });
        });

        window.updateResourcePersonalUser = function (selectedLi) {
            const parentType = selectedLi.parentElement.parentElement.firstChild.textContent.trim();
            const user = selectedLi.textContent.trim();
            resourceSelectBtn.firstElementChild.innerText = `Personal ${parentType} (${user})`;
            resourceWrapper.classList.remove("active");
            document.querySelectorAll('.option .has-sub').forEach(el => el.classList.remove('active'));
        };
    }

    // =======================
    // Custom Dropdown Project Type
    // =======================
    const projectTypeWrapper = document.querySelector('.wrapp.project-type-dropdown');
    if (projectTypeWrapper) {
        const projectTypeSelectBtn = projectTypeWrapper.querySelector('.select-btn');
        const projectTypeOptions = projectTypeWrapper.querySelectorAll('.option li');
        if (projectTypeSelectBtn) {
            projectTypeSelectBtn.addEventListener("click", function (e) {
                e.stopPropagation();
                const isActive = projectTypeWrapper.classList.contains("active");
                closeAllDropdowns();
                if (!isActive) projectTypeWrapper.classList.add("active");
            });
        }
        projectTypeOptions.forEach(option => {
            option.addEventListener('click', function (e) {
                e.stopPropagation();
                projectTypeSelectBtn.firstElementChild.innerText = this.innerText;
                projectTypeWrapper.classList.remove("active");
            });
        });
    }

    // =======================
    // Custom Dropdown Opportunity
    // =======================
    const opportunityWrapper = document.getElementById('opportunity-dropdown');
    if (opportunityWrapper) {
        const opportunitySelectBtn = opportunityWrapper.querySelector('.select-btn');
        const opportunityOptions = opportunityWrapper.querySelectorAll('.option li');
        if (opportunitySelectBtn) {
            opportunitySelectBtn.addEventListener("click", function (e) {
                e.stopPropagation();
                const isActive = opportunityWrapper.classList.contains("active");
                closeAllDropdowns();
                if (!isActive) opportunityWrapper.classList.add("active");
            });
        }
        opportunityOptions.forEach(option => {
            option.addEventListener('click', function (e) {
                e.stopPropagation();
                opportunitySelectBtn.firstElementChild.innerText = this.innerText;
                opportunityWrapper.classList.remove("active");
            });
        });
    }

    // Klik di luar dropdown untuk menutup semua
    document.addEventListener('click', function () {
        closeAllDropdowns();
    });

    // =======================
    // Tabs Customer Contact
    // =======================
    const tabButtons = document.querySelectorAll(".customer-contact-tab");
    const tabPanels = document.querySelectorAll(".customer-contact-panel");
    if (tabButtons.length && tabPanels.length) {
        tabButtons.forEach(btn => {
            btn.addEventListener("click", function () {
                tabButtons.forEach(b => {
                    b.classList.remove("active");
                    b.setAttribute("aria-selected", "false");
                    b.setAttribute("tabindex", "-1");
                });
                this.classList.add("active");
                this.setAttribute("aria-selected", "true");
                this.setAttribute("tabindex", "0");
                tabPanels.forEach(panel => {
                    if (panel.id === this.getAttribute("aria-controls")) {
                        panel.removeAttribute("hidden");
                    } else {
                        panel.setAttribute("hidden", "");
                    }
                });
            });
        });
        // Set default tab active
        tabButtons[0].click();
    }

    // =======================
    // Due Date Otomatis
    // =======================
    const requestDateInput = document.getElementById('request-date');
    const dueDateInput = document.getElementById('due-date');
    if (requestDateInput && dueDateInput) {
        requestDateInput.addEventListener('change', function () {
            const requestDateValue = this.value;
            if (requestDateValue) {
                const requestDate = new Date(requestDateValue);
                requestDate.setDate(requestDate.getDate() + 2);
                const year = requestDate.getFullYear();
                const month = String(requestDate.getMonth() + 1).padStart(2, '0');
                const day = String(requestDate.getDate()).padStart(2, '0');
                const dueDateValue = `${year}-${month}-${day}`;
                dueDateInput.value = dueDateValue;
            } else {
                dueDateInput.value = '';
            }
        });
    }

    // =======================
    // Table Row Functions
    // =======================
    // Item Table
    const addRowBtn = document.getElementById('addRowBtn');
    const itemTableBody = document.getElementById('itemTableBody');
    if (addRowBtn && itemTableBody) {
        addRowBtn.addEventListener('click', () => {
            const rowCount = itemTableBody.children.length + 1;
            const newRow = document.createElement('tr');
            newRow.innerHTML = `
                <td>${rowCount}</td>
                <td class="name"><input type='text' class='size form-control1'></td>
                <td class="desc"><input type='text' class='size form-control1'></td>
                <td class="qty"><input type='number' class='size form-control1' value="0"></td>
                <td class="uom"><input type='text' class='size tengah form-control1'></td>
                <td class="budget"><input type='number' class='size form-control1'></td>
                <td class="leadtime"><input type='text' class='size tengah form-control1'></td>
                <td class="delete"><button type="button" class="btn btn-danger btn-sm btn-remove-row"><i class='bx bx-trash'></i></button></td>
            `;
            itemTableBody.appendChild(newRow);
        });
        itemTableBody.addEventListener('click', function (e) {
            if (e.target.closest('.btn-remove-row')) {
                const row = e.target.closest('tr');
                if (row) itemTableBody.removeChild(row);
                // Update nomor urut
                Array.from(itemTableBody.children).forEach((tr, i) => {
                    tr.querySelector('td').innerText = i + 1;
                });
            }
        });
    }

    // Item List Table
    const addRowBtnItem = document.getElementById('addRowBtnItem');
    const itemListTableBody = document.getElementById('itemListTableBody');
    if (addRowBtnItem && itemListTableBody) {
        addRowBtnItem.addEventListener('click', () => {
            const rowCount = itemListTableBody.children.length + 1;
            const newRow = document.createElement('tr');
            newRow.innerHTML = `
                <td>${rowCount}</td>
                <td class="name"><input type='text' class='size form-control1'></td>
                <td class="desc"><input type='text' class='size form-control1'></td>
                <td class="qty"><input type='number' class='size form-control1' value="0"></td>
                <td class="uom"><input type='text' class='size tengah form-control1'></td>
                <td class="price"><input type='number' class='size form-control1'></td>
                <td class="notes"><input type='text' class='size form-control1'></td>
                <td class="details"><input type='text' class='size form-control1'></td>
                <td class="warranty"><input type='text' class='size form-control1'></td>
                <td class="amount"><input type='number' class='size form-control1'></td>
                <td class="delete"><button type="button" class="btn btn-danger btn-sm btn-remove-row-itemlist"><i class='bx bx-trash'></i></button></td>
            `;
            itemListTableBody.appendChild(newRow);
        });
        itemListTableBody.addEventListener('click', function (e) {
            if (e.target.closest('.btn-remove-row-itemlist')) {
                const row = e.target.closest('tr');
                if (row) itemListTableBody.removeChild(row);
                // Update nomor urut
                Array.from(itemListTableBody.children).forEach((tr, i) => {
                    tr.querySelector('td').innerText = i + 1;
                });
            }
        });
    }

    // Request Item Table
    const addRowBtnReq = document.getElementById('addRowBtnReq');
    const reqTableBody = document.getElementById('reqTableBody');
    if (addRowBtnReq && reqTableBody) {
        addRowBtnReq.addEventListener('click', () => {
            const rowCount = reqTableBody.children.length + 1;
            const newRow = document.createElement('tr');
            newRow.innerHTML = `
                <td class="action"><button type="button" class="btn"><i class='bx bx-plus-circle'></i></button></td>
                <td class="nomor" style="padding: 14px 9px;">${rowCount}</td>
                <td class="reqCode"><input type='text' class='tengah size form-control1'></td>
                <td class="name"><input type='text' class='size form-control1'></td>
                <td class="desc"><input type='text' class='size form-control1'></td>
                <td class="qty"><input type='number' class='size form-control1' value="0"></td>
                <td class="uom"><input type='text' class='size tengah form-control1'></td>
                <td class="reason"><input type='text' class='size form-control1'></td>
                <td class="notes"><input type='text' class='size form-control1'></td>
                <td class="pic"><input type='text' class='size form-control1'></td>
                <td class="status"><input type='text' class='size form-control1'></td>
                <td class="delete"><button type="button" class="btn btn-danger btn-sm btn-remove-row-req"><i class='bx bx-trash'></i></button></td>
            `;
            reqTableBody.appendChild(newRow);
        });
        reqTableBody.addEventListener('click', function (e) {
            if (e.target.closest('.btn-remove-row-req')) {
                const row = e.target.closest('tr');
                if (row) reqTableBody.removeChild(row);
                // Update nomor urut (kolom ke-2)
                Array.from(reqTableBody.children).forEach((tr, i) => {
                    tr.querySelectorAll('td')[1].innerText = i + 1;
                });
            }
        });
    }

    // =======================
    // File Upload Area
    // =======================
    let uploadedFiles = [];
    const formUpload = document.querySelector('.form-upload');
    const fileInput = document.querySelector(".file-input");
    const attachedFilesContainer = document.getElementById('attached-files');
    const attachmentCount = document.querySelector('.attachment-count');

    function updateCount() {
        if (attachmentCount) attachmentCount.textContent = uploadedFiles.length;
        if (attachedFilesContainer) attachedFilesContainer.style.display = uploadedFiles.length > 0 ? 'block' : 'none';
    }

    function createFileInfo(file, nameOfFile) {
        let iconClass = 'fas fa-file';
        if (file.type.startsWith('image/')) iconClass = 'fas fa-file-image';
        else if (file.type.startsWith('application/pdf')) iconClass = 'fas fa-file-pdf';
        else if (file.type.startsWith('application/msword') || file.type.startsWith('application/vnd.openxmlformats-officedocument.wordprocessingml.document')) iconClass = 'fas fa-file-word';

        let fileTotal = Math.floor(file.size / 1024);
        let fileSize = (fileTotal < 1000) ? fileTotal + " KB" : (file.size / (1024 * 1024)).toFixed(2) + " MB";
        const fileInfo = document.createElement('div');
        fileInfo.classList.add('row');
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
        `;

        const downloadBtn = fileInfo.querySelector('.download-button');
        if (downloadBtn) {
            downloadBtn.addEventListener('click', () => {
                const url = URL.createObjectURL(file);
                const a = document.createElement('a');
                a.href = url;
                a.download = file.name;
                document.body.appendChild(a);
                a.click();
                document.body.removeChild(a);
                URL.revokeObjectURL(url);
            });
        }

        const deleteBtn = fileInfo.querySelector('.delete-button');
        if (deleteBtn) {
            deleteBtn.addEventListener('click', () => {
                const fileIndex = uploadedFiles.indexOf(file);
                if (fileIndex > -1) uploadedFiles.splice(fileIndex, 1);
                if (attachedFilesContainer) attachedFilesContainer.removeChild(fileInfo);
                updateCount();
            });
        }

        return fileInfo;
    }

    if (formUpload && fileInput && attachedFilesContainer && attachmentCount) {
        formUpload.addEventListener("click", () => {
            fileInput.click();
        });

        fileInput.addEventListener('change', () => {
            const currentCount = uploadedFiles.length;
            if (currentCount >= 5) {
                alert('Maksimum 5 berkas diperbolehkan.');
                return;
            }
            const newFiles = Array.from(fileInput.files);
            const maxToAdd = 5 - currentCount;
            const filesToAdd = newFiles.slice(0, maxToAdd);
            if (filesToAdd.length < newFiles.length) {
                alert(`Hanya ${maxToAdd} berkas lagi yang dapat ditambahkan. ${maxToAdd} berkas pertama akan ditambahkan.`);
            }
            filesToAdd.forEach((file) => {
                uploadedFiles.push(file);
                let fileName = file.name;
                if (fileName.length >= 20) {
                    let splitName = fileName.split('.');
                    fileName = splitName[0].substring(0, 21) + "... ." + splitName[1];
                }
                const fileInfo = createFileInfo(file, fileName);
                attachedFilesContainer.appendChild(fileInfo);
            });
            updateCount();
            fileInput.value = '';
        });
    }

    // =======================
    // Request Item to Purchasing Popup (jika ada)
    // =======================
    const requestItemBtn = document.querySelector("#request-item-to-purchasing-option");
    const requestItemModal = document.querySelector(".request-item-to-purchasing-form-pop-up");
    const requestItemCloseBtn = document.querySelector(".request-item-to-purchasing-form-close-btn");
    const requestItemCancelBtn = document.querySelector(".request-item-to-purchasing-form-cancel-btn");

    if (requestItemBtn && requestItemModal) {
        requestItemBtn.addEventListener("click", function () {
            requestItemModal.classList.add("active");
            document.body.classList.add("pop-up-active");
            requestItemModal.scrollTop = 0;
        });
    }
    if (requestItemCloseBtn && requestItemModal) {
        requestItemCloseBtn.addEventListener("click", function () {
            requestItemModal.classList.remove("active");
            document.body.classList.remove("pop-up-active");
        });
    }
    if (requestItemCancelBtn && requestItemModal) {
        requestItemCancelBtn.addEventListener("click", function () {
            requestItemModal.classList.remove("active");
            document.body.classList.remove("pop-up-active");
        });
    }

    // =======================
    // Table Sortable (jika ada)
    // =======================
    function sortTableByColumn(table, column, asc = true) {
        const dirModifier = asc ? 1 : -1;
        const tBody = table.tBodies[0];
        const rows = Array.from(tBody.querySelectorAll("tr"));

        const sortedRows = rows.sort((a, b) => {
            const aText = a.querySelector(`td:nth-child(${column + 1})`).textContent.trim();
            const bText = b.querySelector(`td:nth-child(${column + 1})`).textContent.trim();
            const aVal = isNaN(aText) ? aText.toLowerCase() : parseFloat(aText);
            const bVal = isNaN(bText) ? bText.toLowerCase() : parseFloat(bText);
            if (aVal < bVal) return -1 * dirModifier;
            if (aVal > bVal) return 1 * dirModifier;
            return 0;
        });

        while (tBody.firstChild) {
            tBody.removeChild(tBody.firstChild);
        }
        tBody.append(...sortedRows);

        table.querySelectorAll("th").forEach(th =>
            th.classList.remove("th-sort-asc", "th-sort-desc")
        );
        const th = table.querySelector(`th:nth-child(${column + 1})`);
        th.classList.toggle("th-sort-asc", asc);
        th.classList.toggle("th-sort-desc", !asc);
    }

    document.querySelectorAll(".table-sortable th").forEach(headerCell => {
        headerCell.addEventListener("click", () => {
            const table = headerCell.closest("table");
            const headerIndex = Array.from(headerCell.parentElement.children).indexOf(headerCell);
            const currentIsAscending = headerCell.classList.contains("th-sort-asc");
            sortTableByColumn(table, headerIndex, !currentIsAscending);
        });
    });

});
