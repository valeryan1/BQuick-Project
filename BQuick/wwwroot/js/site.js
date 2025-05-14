function search() {
    const input = document.getElementById("searchInput");
    const filter = input.value.toLowerCase();
    const table = document.querySelector(".table-sortable");
    const trs = table.getElementsByTagName("tr");
    for (let i = 1; i < trs.length; i++) {
        const tds = trs[i].getElementsByTagName("td");
        let match = false;
        for (let j = 0; j < tds.length; j++) {
            if (tds[j].textContent.toLowerCase().indexOf(filter) > -1) {
                match = true;
                break;
            }
        }
        trs[i].style.display = match ? "" : "none";
    }
}

function closeAllDropdowns() {
    document.querySelectorAll('.wrapp').forEach(wrapper => {
        wrapper.classList.remove('active');
    });
    document.querySelectorAll('.option .has-sub').forEach(el => el.classList.remove('active'));
}

function getCompanyCode(name) {
    return name
        .split(/\s+/)
        .map(w => w[0])
        .filter(Boolean)
        .join('')
        .toUpperCase();
}

function removeRow(button) {
    const row = button.parentNode.parentNode;
    itemTableBody.removeChild(row);

    const rows = itemTableBody.getElementsByTagName('tr');
    for (let i = 0; i < rows.length; i++) {
        rows[i].getElementsByTagName('td')[0].innerText = i + 1;
    }
}

function removeRowItemList(button) {
    const row = button.parentNode.parentNode;
    itemListTableBody.removeChild(row);

    const rows = itemListTableBody.getElementsByTagName('tr');
    for (let i = 0; i < rows.length; i++) {
        rows[i].getElementsByTagName('td')[0].innerText = i + 1;
    }
}

function removeRowReq(button) {
    const row = button.parentNode.parentNode;
    reqTableBody.removeChild(row);

    const rows = reqTableBody.getElementsByTagName('tr');
    for (let i = 0; i < rows.length; i++) {
        rows[i].getElementsByTagName('td')[1].innerText = i + 1;
    }
}

document.addEventListener("DOMContentLoaded", function () {
    document.querySelectorAll('form').forEach(form => {
        form.addEventListener('keydown', function (e) {
            if (e.key === 'Enter') {
                if (
                    e.target.tagName !== 'TEXTAREA' &&
                    e.target.type !== 'submit' &&
                    e.target.type !== 'button'
                ) {
                    e.preventDefault();
                    return false;
                }
            }
        });
    });

    const hamburger = document.querySelector(".toggle-btn");
    const toggler = document.querySelector("#icon");
    if (hamburger && toggler) {
        hamburger.addEventListener("click", function () {
            document.querySelector("#sidebar").classList.toggle("expand");
            toggler.classList.toggle("bx-chevrons-right");
            toggler.classList.toggle("bx-chevrons-left");
        });
    }

    const table = document.querySelector('.table-sortable');
    if (table) {
        const ths = table.querySelectorAll('thead th');
        let sortState = {};

        ths.forEach((th, idx) => {
            th.style.cursor = 'pointer';
            th.addEventListener('click', function () {
                let state = sortState[idx];
                if (!state) state = 'asc';
                else if (state === 'asc') state = 'desc';
                else state = null;

                ths.forEach((oth, i) => {
                    sortState[i] = null;
                    const icons = oth.querySelector('.sort-icons');
                    if (icons) icons.innerHTML = "<i class='bx bxs-up-arrow'></i><i class='bx bxs-down-arrow'></i>";
                    icons?.querySelectorAll('.bx').forEach(icon => icon.style.opacity = 0.3);
                });

                sortState[idx] = state;
                const icons = th.querySelector('.sort-icons');
                if (icons) {
                    if (state === 'asc') {
                        icons.innerHTML = "<i class='bx bxs-up-arrow'></i>";
                    } else if (state === 'desc') {
                        icons.innerHTML = "<i class='bx bxs-down-arrow'></i>";
                    } else {
                        icons.innerHTML = "<i class='bx bxs-up-arrow'></i><i class='bx bxs-down-arrow'></i>";
                        icons.querySelectorAll('.bx').forEach(icon => icon.style.opacity = 0.3);
                    }
                }

                if (state) sortTable(table, idx, state === 'desc');
            });

            const icons = th.querySelector('.sort-icons');
            if (icons) {
                icons.innerHTML = "<i class='bx bxs-up-arrow'></i><i class='bx bxs-down-arrow'></i>";
                icons.querySelectorAll('.bx').forEach(icon => icon.style.opacity = 0.3);
            }
        });

        function sortTable(table, col, desc) {
            const tbody = table.tBodies[0];
            const rows = Array.from(tbody.querySelectorAll('tr'));
            rows.sort((a, b) => {
                const A = a.children[col].textContent.trim();
                const B = b.children[col].textContent.trim();
                return desc ? B.localeCompare(A, undefined, { numeric: true }) : A.localeCompare(B, undefined, { numeric: true });
            });
            rows.forEach(row => tbody.appendChild(row));
        }
    }

    const addBtn = document.getElementById('add-customer-contact-btn');
    const formPopUp = document.querySelector('.add-customer-contact-form-pop-up');
    const closeChevron = document.getElementById('customer-contact-form-open-chevron');

    if (formPopUp) formPopUp.style.display = 'none';
    if (addBtn) addBtn.style.display = 'block';

    if (addBtn && formPopUp) {
        addBtn.addEventListener('click', function () {
            formPopUp.querySelectorAll('input, select, textarea').forEach(el => {
                if (el.type === 'checkbox' || el.type === 'radio') {
                    el.checked = false;
                } else if (el.type === 'file') {
                    el.value = null;
                } else {
                    el.value = '';
                }
            });
            formPopUp.style.display = 'block';
            addBtn.style.display = 'none';

            const infoPopUp = document.querySelector('.show-customer-contact-information-form-pop-up');
            const openChevron = document.getElementById('customer-contact-information-form-close-chevron');
            const closeBtn = document.getElementById('customer-contact-information-form-open-minus');
            if (infoPopUp) infoPopUp.classList.add('active');
            if (openChevron) openChevron.style.display = 'none';
            if (closeBtn) closeBtn.style.display = 'inline-block';
        });
    }

    if (closeChevron && formPopUp && addBtn) {
        closeChevron.addEventListener('click', function () {
            formPopUp.style.display = 'none';
            addBtn.style.display = 'block';
        });
    }

    const infoPopUp = document.querySelector('.show-customer-contact-information-form-pop-up');
    const closeBtn = document.getElementById('customer-contact-information-form-open-minus');
    const openChevron = document.getElementById('customer-contact-information-form-close-chevron');

    if (infoPopUp) infoPopUp.classList.add('active');
    if (openChevron) openChevron.style.display = 'none';
    if (closeBtn) closeBtn.style.display = 'inline-block';

    if (closeBtn && infoPopUp && openChevron) {
        closeBtn.addEventListener('click', function () {
            infoPopUp.classList.remove('active');
            openChevron.style.display = 'inline-block';
            closeBtn.style.display = 'none';
        });
    }

    if (openChevron && infoPopUp && closeBtn) {
        openChevron.addEventListener('click', function () {
            infoPopUp.classList.add('active');
            openChevron.style.display = 'none';
            closeBtn.style.display = 'inline-block';
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

            if (window.companies && window.addCompany && window.companyWrapper) {
                if (!companies.includes(companyName)) {
                    companies.unshift(companyName);
                }
                const code = getCompanyCode(companyName);
                companyWrapper.querySelector(".select-btn").firstElementChild.innerText = code ? `${companyName} (${code})` : companyName;
                companyWrapper.querySelector("input").value = "";
                addCompany(companyName);
                companyWrapper.classList.remove("active");

                const mainCompanyDropdown = document.querySelector('.wrapp.company-dropdown .select-btn span');
                if (mainCompanyDropdown) mainCompanyDropdown.innerText = code ? `${companyName} (${code})` : companyName;
            }
        });
    });

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
                modal.scrollTop = 0;
                const companyNameInput = modal.querySelector('input[placeholder="Company Name"]');
                if (companyNameInput) companyNameInput.value = name;
                const contactFormPopUp = document.querySelector('.add-customer-contact-form-pop-up');
                const addContactBtn = document.getElementById('add-customer-contact-btn');
                if (contactFormPopUp) contactFormPopUp.style.display = 'none';
                if (addContactBtn) addContactBtn.style.display = 'block';
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

    document.querySelectorAll('.add-customer-contact-form-pop-up .btn-success').forEach(btn => {
        btn.addEventListener('click', function () {
            const nameInput = document.getElementById('customer-contact-name');
            const titleSelect = document.getElementById('customer-contact-title');
            const endUserInput = document.getElementById('end-user');
            if (nameInput && titleSelect && endUserInput) {
                const name = nameInput.value.trim();
                const title = titleSelect.value;
                endUserInput.value = title && name ? `${title} ${name}` : name;
            }
        });
    });

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

    document.addEventListener('click', function () {
        closeAllDropdowns();
    });

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
        tabButtons[0].click();
    }

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
                <td class="qty"><input type='number' class='size form-control1'></td>
                <td class="uom"><input type='text' class='size tengah form-control1'></td>
                <td class="budget"><input type='number' class='size form-control1'></td>
                <td class="leadtime"><input type='text' class='size tengah form-control1'></td>
                <td class="delete"><button type="button" onclick="removeRow(this)" class="btn"><i class='bx bx-trash'></i></button>
            `;
            itemTableBody.appendChild(newRow);
        });
        itemTableBody.addEventListener('click', function (e) {
            if (e.target.closest('.btn-remove-row')) {
                const row = e.target.closest('tr');
                if (row) itemTableBody.removeChild(row);
                Array.from(itemTableBody.children).forEach((tr, i) => {
                    tr.querySelector('td').innerText = i + 1;
                });
            }
        });
    }

    const addRowBtnItem = document.getElementById('addRowBtnItem');
    const itemListTableBody = document.getElementById('itemListTableBody');

    if (addRowBtnItem && itemListTableBody) {
        addRowBtnItem.addEventListener('click', () => {
            const lastRow = itemListTableBody.lastElementChild;
            if (lastRow) {
                const fields = [
                    lastRow.querySelector('td.name input'),
                    lastRow.querySelector('td.desc input'),
                    lastRow.querySelector('td.qty input'),
                    lastRow.querySelector('td.uom input'),
                    lastRow.querySelector('td.price input'),
                    lastRow.querySelector('td.notes input'),
                    lastRow.querySelector('td.details input'),
                    lastRow.querySelector('td.warranty input'),
                    lastRow.querySelector('td.amount input')
                ];
                const isAnyFilled = fields.some(input => input && input.value.trim() !== '');
                if (!isAnyFilled) {
                    return;
                }
            }
            const rowCount = itemListTableBody.children.length + 1;
            const newRow = document.createElement('tr');
            newRow.innerHTML = `
            <td>${rowCount}</td>
            <td class="name"><input type='text' class='size form-control1'></td>
            <td class="desc"><input type='text' class='size form-control1'></td>
            <td class="qty"><input type='number' class='size form-control1'></td>
            <td class="uom"><input type='text' class='size tengah form-control1'></td>
            <td class="price"><input type='number' class='size form-control1'></td>
            <td class="notes"><input type='text' class='size form-control1'></td>
            <td class="details"><input type='text' class='size form-control1'></td>
            <td class="warranty"><input type='text' class='size form-control1'></td>
            <td class="amount"><input type='number' class='size form-control1'></td>
            <td class="delete"><button type="button" onclick="removeRowItemList(this)" class="btn"><i class='bx bx-trash'></i></button></td>
        `;
            itemListTableBody.appendChild(newRow);
        });
    }

    const addRowBtnReq = document.getElementById('addRowBtnReq');
    const reqTableBody = document.getElementById('reqTableBody');

    if (addRowBtnReq && reqTableBody) {
        addRowBtnReq.addEventListener('click', () => {
            const lastRow = reqTableBody.lastElementChild;
            if (lastRow) {
                const fields = [
                    lastRow.querySelector('td.reqCode input'),
                    lastRow.querySelector('td.name input'),
                    lastRow.querySelector('td.desc input'),
                    lastRow.querySelector('td.qty input'),
                    lastRow.querySelector('td.uom input'),
                    lastRow.querySelector('td.reason input'),
                    lastRow.querySelector('td.notes input'),
                    lastRow.querySelector('td.pic input'),
                    lastRow.querySelector('td.status input')
                ];
                const isAnyFilled = fields.some(input => input && input.value.trim() !== '');
                if (!isAnyFilled) {
                    return;
                }
            }
            const rowCount = reqTableBody.children.length + 1;
            const newRow = document.createElement('tr');
            newRow.innerHTML = `
            <td class="action"><button type="button" class="btn"><i class='bx bx-plus-circle'></i></button></td>
            <td class="nomor" style="padding: 14px 9px;">${rowCount}</td>
            <td class="reqCode"><input type='text' class='tengah size form-control1'></td>
            <td class="name"><input type='text' class='size form-control1'></td>
            <td class="desc"><input type='text' class='size form-control1'></td>
            <td class="qty"><input type='number' class='size form-control1'></td>
            <td class="uom"><input type='text' class='size tengah form-control1'></td>
            <td class="reason"><input type='text' class='size form-control1'></td>
            <td class="notes"><input type='text' class='size form-control1'></td>
            <td class="pic"><input type='text' class='size form-control1'></td>
            <td class="status"><input type='text' class='size form-control1'></td>
            <td class="delete"><button type="button" onclick="removeRowReq(this)" class="btn btn-remo"><i class='bx bx-trash'></i></button></td>
        `;
            reqTableBody.appendChild(newRow);
        });
    }

    document.getElementById('reqTableBody').addEventListener('click', function (e) {
        if (e.target.closest('.bx-plus-circle')) {
            const row = e.target.closest('tr');
            if (!row) return;

            const name = row.querySelector('td.name input').value.trim();
            const desc = row.querySelector('td.desc input').value.trim();
            const qty = row.querySelector('td.qty input').value.trim();
            const uom = row.querySelector('td.uom input').value.trim();

            if (!(name || desc || qty || uom)) return;

            const itemListTbody = document.getElementById('itemListTableBody');
            let foundEmptyRow = null;
            for (const tr of itemListTbody.children) {
                const inputs = tr.querySelectorAll('input');
                const allEmpty = Array.from(inputs).every(input => input.value.trim() === '');
                if (allEmpty) {
                    foundEmptyRow = tr;
                    break;
                }
            }

            let targetRow;
            if (foundEmptyRow) {
                targetRow = foundEmptyRow;
            } else {
                const rowCount = itemListTbody.children.length + 1;
                targetRow = document.createElement('tr');
                targetRow.innerHTML = `
                <td>${rowCount}</td>
                <td class="name"><input type='text' class='size form-control1'></td>
                <td class="desc"><input type='text' class='size form-control1'></td>
                <td class="qty"><input type='number' class='size form-control1'></td>
                <td class="uom"><input type='text' class='size tengah form-control1'></td>
                <td class="price"><input type='number' class='size form-control1'></td>
                <td class="notes"><input type='text' class='size form-control1'></td>
                <td class="details"><input type='text' class='size form-control1'></td>
                <td class="warranty"><input type='text' class='size form-control1'></td>
                <td class="amount"><input type='number' class='size form-control1'></td>
                <td class="delete"><button type="button" class="btn btn-remove-row-itemlist"><i class='bx bx-trash'></i></button></td>
            `;
                itemListTbody.appendChild(targetRow);
            }

            targetRow.querySelector('td.name input').value = name;
            targetRow.querySelector('td.desc input').value = desc;
            targetRow.querySelector('td.qty input').value = qty;
            targetRow.querySelector('td.uom input').value = uom;

            row.parentNode.removeChild(row);

            Array.from(itemListTbody.children).forEach((tr, i) => {
                tr.querySelector('td').innerText = i + 1;
            });
            const reqTableBody = document.getElementById('reqTableBody');
            Array.from(reqTableBody.children).forEach((tr, i) => {
                tr.querySelectorAll('td')[1].innerText = i + 1;
            });
        }
    });

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
                    <button class="download-button float-end me-2"><i class="fas fa-download"></i></button> 
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
                alert('You can only upload a maximum of 5 files.');
                return;
            }
            const newFiles = Array.from(fileInput.files);
            const maxToAdd = 5 - currentCount;
            const filesToAdd = newFiles.slice(0, maxToAdd);

            const validFiles = [];
            filesToAdd.forEach(file => {
                if (file.size > 5 * 1024 * 1024) {
                    alert(`File "${file.name}" is more than 5MB and cannot be uploaded.`);
                } else {
                    validFiles.push(file);
                }
            });

            if (validFiles.length < filesToAdd.length) {
                alert('Some files cannot be uploaded because exceed 5MB.');
            }

            validFiles.forEach((file) => {
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
    // Request Item to Purchasing Pop-up (temporary)
    // =======================
    //const requestItemBtn = document.querySelector("#request-item-to-purchasing-option");
    //const requestItemModal = document.querySelector(".request-item-to-purchasing-form-pop-up");
    //const requestItemCloseBtn = document.querySelector(".request-item-to-purchasing-form-close-btn");
    //const requestItemCancelBtn = document.querySelector(".request-item-to-purchasing-form-cancel-btn");

    //if (requestItemBtn && requestItemModal) {
    //    requestItemBtn.addEventListener("click", function () {
    //        requestItemModal.classList.add("active");
    //        document.body.classList.add("pop-up-active");
    //    });
    //}
    //if (requestItemCloseBtn && requestItemModal) {
    //    requestItemCloseBtn.addEventListener("click", function () {
    //        requestItemModal.classList.remove("active");
    //        document.body.classList.remove("pop-up-active");
    //    });
    //}
    //if (requestItemCancelBtn && requestItemModal) {
    //    requestItemCancelBtn.addEventListener("click", function () {
    //        requestItemModal.classList.remove("active");
    //        document.body.classList.remove("pop-up-active");
    //    });
    //}
});
