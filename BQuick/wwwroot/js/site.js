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

function disableAllDropdowns() {
    document.querySelectorAll('select').forEach(el => el.disabled = true);
    document.querySelectorAll('.wrapp').forEach(wrapper => {
        wrapper.classList.add('disabled-by-script');
        wrapper.setAttribute('tabindex', '-1');
    });
}

function enableAllDropdowns() {
    document.querySelectorAll('select').forEach(el => el.disabled = false);
    document.querySelectorAll('.wrapp').forEach(wrapper => {
        wrapper.classList.remove('disabled-by-script');
        wrapper.removeAttribute('tabindex');
    });
}

function disableAllFormFields() {
    document.querySelectorAll('input, select, textarea, button').forEach(el => {
        if (el.classList.contains('toggle-btn')) return;
        if (el.closest('#buttonGroup')) return;
        el.disabled = true;
    });
    document.querySelectorAll('.form-upload, .file-input').forEach(el => {
        el.classList.add('disabled-by-script');
        el.disabled = true;
    });
    disableAllDropdowns();

    const rfqInput = document.getElementById('rfq-name');
    if (rfqInput) {
        rfqInput.classList.add('is-floating');
    }
}

function enableAllFormFields() {
    document.querySelectorAll('input, select, textarea, button').forEach(el => {
        el.disabled = false;
    });
    document.querySelectorAll('.form-upload, .file-input').forEach(el => {
        el.classList.remove('disabled-by-script');
        el.disabled = false;
    });
    enableAllDropdowns();

    const rfqInput = document.getElementById('rfq-name');
    if (rfqInput) {
        rfqInput.classList.remove('is-floating');
    }
}

function resetCompanyForm(modal) {
    modal.querySelectorAll('input, select, textarea').forEach(el => {
        el.disabled = false;
        if (el.type === 'checkbox' || el.type === 'radio') {
            el.checked = false;
        } else if (el.type === 'file') {
            el.value = null;
        } else {
            el.value = '';
        }
    });
}

function getCompanyCode(name) {
    return name
        .split(/\s+/)
        .map(w => w[0])
        .filter(Boolean)
        .join('')
        .toUpperCase();
}

function updateCompanyNameDisplay() {
    const companyWrapper = document.querySelector('.wrapp.company-dropdown');
    const companySpan = companyWrapper?.querySelector('.select-btn span');
    const resourceWrapper = document.querySelector('.wrapp.resource-dropdown');
    const resourceSpan = resourceWrapper?.querySelector('.select-btn span');

    if (!companySpan || !resourceSpan) return;

    let companyName = companySpan.textContent.split(' (')[0].trim();

    if (!companyName) {
        companySpan.textContent = '';
        return;
    }

    const isExistingCompany = Array.isArray(window.companies) && window.companies.some(
        c => c.trim().toLowerCase() === companyName.trim().toLowerCase()
    );

    if (!isExistingCompany) {
        const modal = document.querySelector('.add-customer-form-pop-up');
        if (modal && modal.classList.contains('active')) {
            const companyNameInput = modal.querySelector('input[placeholder="Company Name"]');
            if (companyNameInput && companyNameInput.value.trim()) {
                companyName = companyNameInput.value.trim();
            }
        }
    }

    const createMatch = companyName.match(/^Create\s+"(.+)"$/);
    if (createMatch) {
        companyName = createMatch[1];
    }

    if (
        resourceSpan.textContent.trim().startsWith('Personal') &&
        companyName
    ) {
        companySpan.textContent = `${companyName} (Pers - ${companyName})`;
    } else {
        const code = getCompanyCode(companyName);
        companySpan.textContent = code ? `${companyName} (${code})` : companyName;
    }
}

function updateCompanyStatusLabel(status) {
    const notYet = document.getElementById('not-yet');
    const waitingAssign = document.getElementById('waiting-assign');
    const companyWrapper = document.querySelector('.wrapp.company-dropdown');
    if (!companyWrapper) return;

    const companyDisplay = companyWrapper.querySelector('.select-btn span');
    const companyName = companyDisplay ? companyDisplay.innerText.split(' (')[0].trim() : '';

    if (!companyName) {
        if (notYet) notYet.style.display = 'none';
        if (waitingAssign) waitingAssign.style.display = 'none';
        return;
    }

    if (window.currentCompanyIsNew) {
        if (status === 'not-yet') {
            if (notYet) notYet.style.display = 'inline-flex';
            if (waitingAssign) waitingAssign.style.display = 'none';
        } else if (status === 'waiting-assign') {
            if (notYet) notYet.style.display = 'none';
            if (waitingAssign) waitingAssign.style.display = 'inline-flex';
        }
    } else {
        if (notYet) notYet.style.display = 'none';
        if (waitingAssign) waitingAssign.style.display = 'none';
    }
}

function renumberTableRows(tableId) {
    const tbody = document.getElementById(tableId);
    if (!tbody) return;

    const rows = tbody.querySelectorAll('tr');
    rows.forEach((row, index) => {
        if (tableId === 'reqTableBody') {
            const numberCell = row.querySelector('td.nomor');
            if (numberCell) {
                numberCell.textContent = (index + 1).toString();
                numberCell.style.fontWeight = '500';
            }
        } else {
            const numberCell = row.querySelector('td:first-child');
            if (numberCell) {
                numberCell.textContent = (index + 1).toString();
                numberCell.style.fontWeight = '500';
            }
        }
    });
}

function renumberItemListTable() {
    const tbody = document.getElementById('itemListTableBody');
    if (!tbody) return;

    const rows = tbody.querySelectorAll('tr');
    const collectionName = 'ItemListSectionItems';

    rows.forEach((row, index) => {
        // Update nomor urut visual
        const numberCell = row.querySelector('td:first-child');
        if (numberCell) {
            numberCell.textContent = (index + 1).toString();
        }

        // Update atribut 'name' untuk semua input, select, textarea
        const inputs = row.querySelectorAll('input, select, textarea');
        inputs.forEach(input => {
            const name = input.getAttribute('name');
            if (name) {
                // Ganti indeks di dalam nama, misal: ItemListSectionItems[5].ItemID -> ItemListSectionItems[0].ItemID
                const newName = name.replace(/\[\d+\]/, `[${index}]`);
                input.setAttribute('name', newName);
            }
        });
    });
}

document.addEventListener('click', function(e) {
    // Event listener untuk tombol hapus di tabel Item List
    const removeBtn = e.target.closest('.btn-remove-row-itemlist');
    if (removeBtn) {
        const row = removeBtn.closest('tr');
        if (row) {
            row.remove();
            renumberItemListTable(); // Panggil fungsi penomoran ulang
            updateItemListTotal();
            updateAddItemButtonState();
        }
    }
});

function renumberReqTable() {
    const tbody = document.getElementById('reqTableBody');
    if (!tbody) return;

    let itemIndex = 1;
    let rows = Array.from(tbody.querySelectorAll('tr'));
    let i = 0;
    while (i < rows.length) {
        const row = rows[i];
        const numberCell = row.querySelector('td.nomor');
        if (numberCell) {
            numberCell.textContent = itemIndex.toString();
            numberCell.style.fontWeight = '500';
        }
        i++;
        let addOnIndex = 1;
        while (i < rows.length) {
            const addOnRow = rows[i];
            const isAddOn = addOnRow.classList.contains('addon-row');
            if (isAddOn) {
                const addOnNumberCell = addOnRow.querySelector('td.nomor');
                if (addOnNumberCell) {
                    addOnNumberCell.textContent = `${itemIndex}.${addOnIndex}`;
                    addOnNumberCell.style.fontWeight = '500';
                }
                addOnIndex++;
                i++;
            } else {
                break;
            }
        }
        itemIndex++;
    }
}

function resetRequestItemToPurchasingForm() {
    const modal = document.querySelector('.request-item-to-purchasing-form-pop-up');
    if (!modal) return;

    modal.querySelectorAll('input, select, textarea').forEach(el => {
        if (el.type === 'checkbox' || el.type === 'radio') {
            el.checked = false;
        } else if (el.type === 'file') {
            el.value = null;
        } else {
            el.value = '';
        }
    });

    modal.querySelectorAll('.wrapper-2').forEach(wrapper => {
        if (wrapper.uploadedFiles) {
            wrapper.uploadedFiles = [];
        }
        const attachedFilesContainer = wrapper.querySelector('#attached-files');
        if (attachedFilesContainer) attachedFilesContainer.innerHTML = '';
        const attachmentCount = wrapper.querySelector('.attachment-count');
        if (attachmentCount) attachmentCount.textContent = '0';
    });
}

function resetConfigureItemForm() {
    const modal = document.querySelector('.configure-item-form-pop-up');
    if (!modal) return;
    modal.querySelectorAll('input, select, textarea').forEach(el => {
        if (el.type === 'checkbox' || el.type === 'radio') {
            el.checked = false;
        } else if (el.type === 'file') {
            el.value = null;
        } else {
            el.value = '';
        }
    });
    document.querySelectorAll('#add-ons-table-body .add-on-checkbox').forEach(cb => cb.checked = false);
}

function checkLastItemListRow() {
    const tbody = document.getElementById('itemListTableBody');
    if (!tbody) return false;

    const rows = tbody.querySelectorAll('tr');
    if (rows.length === 0) return true;

    const lastRow = rows[rows.length - 1];
    const inputs = lastRow.querySelectorAll('input');
    const selectBtnText = lastRow.querySelector('.select-btn span')?.textContent.trim();
    const amountText = lastRow.querySelector('.item-price-amount')?.textContent.trim();

    for (const input of inputs) {
        if (input.value.trim() !== '') return true;
    }

    if (selectBtnText && selectBtnText !== '') return true;

    if (amountText && amountText !== '') return true;

    return false;
}

function updateAddItemButtonState() {
    const addItemBtn = document.getElementById('addRowBtnItem');
    if (addItemBtn) {
        addItemBtn.disabled = !checkLastItemListRow();
    }
}

function updateRowAmount(input) {
    const row = input.closest('tr');
    const qtyInput = row.querySelector('.qty input');
    const priceInput = row.querySelector('.price input');
    const amountSpan = row.querySelector('.amount .item-price-amount');

    if (!qtyInput || !priceInput || !amountSpan) return;

    const qty = parseFloat(qtyInput.value);
    const price = parseFloat(priceInput.value);

    if (!isNaN(qty) && !isNaN(price)) {
        const amount = qty * price;
        amountSpan.textContent = amount.toLocaleString('id-ID');
    } else {
        amountSpan.textContent = '';
    }

    updateItemListTotal();
}

function syncAddOnQtyWithMainItem(mainRow) {
    const mainQtyInput = mainRow.querySelector('.qty input');
    if (!mainQtyInput) return;
    const newQty = mainQtyInput.value;

    let nextRow = mainRow.nextElementSibling;
    while (nextRow && nextRow.classList.contains('addon-row')) {
        const addOnQtyInput = nextRow.querySelector('.qty input');
        if (addOnQtyInput) {
            addOnQtyInput.value = newQty;
            updateRowAmount(addOnQtyInput);
        }
        nextRow = nextRow.nextElementSibling;
    }
}

function clearActiveItemListName() {
    const itemNameCode = document.getElementById('configure-item-name-code');
    if (!itemNameCode) return;
    const itemName = itemNameCode.textContent.split(' [')[0].trim();
    if (!itemName) return;

    const itemListTableBody = document.getElementById('itemListTableBody');
    if (!itemListTableBody) return;
    const rows = itemListTableBody.querySelectorAll('tr');
    for (const row of rows) {
        const nameSpan = row.querySelector('.name .select-btn span');
        if (nameSpan && nameSpan.textContent.trim() === itemName) {
            nameSpan.textContent = '';
            row.querySelectorAll('input').forEach(input => input.value = '');
            row.querySelectorAll('.item-price-amount').forEach(span => span.textContent = '');
            break;
        }
    }
}

function updateItemListTotal() {
    const rows = document.querySelectorAll('#itemListTableBody tr');
    let total = 0;

    rows.forEach(row => {
        const amountText = row.querySelector('.amount .item-price-amount').textContent.trim();
        if (amountText) {
            const amount = parseFloat(amountText.replace(/\./g, '').replace(',', '.'));
            if (!isNaN(amount)) {
                total += amount;
            }
        }
    });

    const totalBox = document.querySelector('#itemListTotalBox .total-value');
    if (totalBox) {
        totalBox.textContent = `Rp${total.toLocaleString('id-ID')}`;
    }
}

function setupMultiSelectDropdown(wrapp) {
    if (!wrapp) return;

    const input = wrapp.querySelector('.select-btn input[type="text"]');
    const chevron = wrapp.querySelector('.select-btn i.bx-chevron-down');
    const optionLis = wrapp.querySelectorAll('.option li');
    const checkboxes = wrapp.querySelectorAll('.option .survey-list-checkboxes');

    function updateInput() {
        const selected = [];
        checkboxes.forEach(cb => {
            if (cb.checked) selected.push(cb.value);
        });
        input.value = selected.join(', ');
    }

    checkboxes.forEach(cb => {
        cb.addEventListener('change', updateInput);
        cb.addEventListener('click', function (e) {
            e.stopPropagation();
        });
    });

    optionLis.forEach(li => {
        li.addEventListener('click', function (e) {
            e.stopPropagation();
            const cb = li.querySelector('.survey-list-checkboxes');
            if (cb) {
                cb.checked = !cb.checked;
                cb.dispatchEvent(new Event('change'));
            }
        });
    });

    if (input) {
        input.addEventListener('click', function (e) {
            e.stopPropagation();
            if (wrapp.classList.contains('active')) {
                wrapp.classList.remove('active');
            } else {
                closeAllDropdowns();
                wrapp.classList.add('active');
            }
        });
    }

    if (chevron) {
        chevron.addEventListener('click', function (e) {
            e.stopPropagation();
            if (wrapp.classList.contains('active')) {
                wrapp.classList.remove('active');
            } else {
                closeAllDropdowns();
                wrapp.classList.add('active');
            }
        });
    }

    wrapp.querySelector('.select-btn').addEventListener('click', function (e) {
        closeAllDropdowns();
        wrapp.classList.add('active');
        e.stopPropagation();
    });

    document.addEventListener('click', function (e) {
        if (!wrapp.contains(e.target)) wrapp.classList.remove('active');
    });
}


function formatRequestDateTime(dateStr, timeStart, timeEnd) {
    if (!dateStr || !timeStart || !timeEnd) return '';
    const days = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];
    const months = [
        'January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'
    ];
    const date = new Date(dateStr + 'T' + timeStart);
    const dayName = days[date.getDay()];
    const day = String(date.getDate()).padStart(2, '0');
    const month = months[date.getMonth()];
    const year = date.getFullYear();

    function formatTime(t) {
        const [h, m] = t.split(':');
        let hour = parseInt(h, 10);
        const min = m;
        const ampm = hour >= 12 ? 'PM' : 'AM';
        hour = hour % 12;
        if (hour === 0) hour = 12;
        return `${hour.toString().padStart(2, '0')}:${min} ${ampm}`;
    }

    return `${dayName}, ${day} ${month} ${year} ${formatTime(timeStart)} - ${formatTime(timeEnd)}`;
}

function resetAssignSalesForm() {
    const popup = document.querySelector('.assign-sales-form-pop-up');
    if (!popup) return;
    popup.querySelectorAll('input, select, textarea').forEach(el => {
        if (el.type === 'checkbox' || el.type === 'radio') {
            el.checked = false;
        } else if (el.type === 'file') {
            el.value = null;
        } else {
            el.value = '';
        }
    });
    const adminSalesSelect = popup.querySelector('.admin-sales-name');
    if (adminSalesSelect) adminSalesSelect.selectedIndex = 0;
    popup.scrollTop = 0;
}

function formatSurveyDateTime(dateStr, timeStart, timeEnd) {
    if (!dateStr || !timeStart || !timeEnd) return '';
    const days = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];
    const months = [
        'January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'
    ];
    const date = new Date(dateStr + 'T' + timeStart);
    const dayName = days[date.getDay()];
    const day = String(date.getDate()).padStart(2, '0');
    const month = months[date.getMonth()];
    const year = date.getFullYear();

    function formatTime(t) {
        const [h, m] = t.split(':');
        let hour = parseInt(h, 10);
        const min = m;
        const ampm = hour >= 12 ? 'PM' : 'AM';
        hour = hour % 12;
        if (hour === 0) hour = 12;
        return `${hour.toString().padStart(2, '0')}:${min} ${ampm}`;
    }

    return `${dayName}, ${day} ${month} ${year} ${formatTime(timeStart)} - ${formatTime(timeEnd)}`;
}

function formatMeetingDateTime(dateStr, timeStart, timeEnd) {
    if (!dateStr || !timeStart || !timeEnd) return '';
    const days = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];
    const months = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];
    const date = new Date(dateStr + 'T' + timeStart);
    const dayName = days[date.getDay()];
    const day = String(date.getDate()).padStart(2, '0');
    const month = months[date.getMonth()];
    const year = date.getFullYear();

    function formatTime(t) {
        const [h, m] = t.split(':');
        let hour = parseInt(h, 10);
        const min = m;
        const ampm = hour >= 12 ? 'PM' : 'AM';
        hour = hour % 12;
        if (hour === 0) hour = 12;
        return `${String(hour).padStart(2, '0')}:${min} ${ampm}`;
    }

    return `${dayName}, ${day} ${month} ${year} ${formatTime(timeStart)} - ${formatTime(timeEnd)}`;
}
function formatFileName(name, maxLength = 20) {
    const dotIndex = name.lastIndexOf('.');
    if (name.length <= maxLength) return name;
    if (dotIndex === -1 || dotIndex === 0) return name.substring(0, maxLength) + '... ';
    const ext = name.substring(dotIndex);
    const base = name.substring(0, maxLength);
    return base + '... ' + ext;
}

function formatCurrency(amount) {
    return `Rp${Number(amount).toLocaleString('id-ID')}`;
}

function parseCurrency(currencyStr) {
    if (!currencyStr) return 0;
    return parseInt(currencyStr.replace(/[^\d]/g, '')) || 0;
}

function updateAddOnsAmount() {
    const configureQtyInput = document.getElementById('configure-item-quantity');
    const configureQty = parseInt(configureQtyInput.value) || 1;
    const addOnsRows = document.querySelectorAll('#add-ons-table-body tr');
    addOnsRows.forEach(row => {
        const qtyCell = row.cells[4];
        const priceCell = row.cells[6];
        const amountCell = row.cells[7];
        if (!qtyCell || !priceCell || !amountCell) return;
        const addOnPrice = parseCurrency(priceCell.textContent.trim());
        priceCell.textContent = formatCurrency(addOnPrice);
        const amount = configureQty * addOnPrice;
        amountCell.textContent = formatCurrency(amount);
    });

    if (typeof window.updateTotalAmountWithAddOns === 'function') {
        window.updateTotalAmountWithAddOns();
    }
}

function addToItemList(name, description, quantity, price, uom = 'Ea') {
    const itemListTableBody = document.getElementById('itemListTableBody');
    if (!itemListTableBody) return;

    const rowCount = itemListTableBody.querySelectorAll('tr').length + 1;
    const amount = quantity * price;

    const newRow = document.createElement('tr');
    newRow.innerHTML = `
        <td class="text-center" style="font-weight: 500;">${rowCount}</td>
        <td class="name">
            <div class="wrapp item-dropdown" style="width: 100%;">
                <div class="select-btn d-flex align-items-center">
                    <span>${name}</span>
                    <i class='bx bx-chevron-down'></i>
                </div>
                <div class="content-search">
                    <div class="search">
                        <i class="bx bx-search-alt-2"></i>
                        <input type="text" placeholder="Search" />
                    </div>
                    <ul class="option" style="margin-bottom: 10px;"></ul>
                </div>
            </div>
        </td>
        <td class="desc"><input type='text' class='size form-control1' value="${description}"></td>
        <td class="qty"><input type='number' class='size text-center form-control1' value="${quantity}"></td>
        <td class="uom"><input type='text' class='size form-control1' value="${uom}"></td>
        <td class="price"><input type='number' class='size form-control1' value="${price}"></td>
        <td class="notes"><input type='text' class='size form-control1'></td>
        <td class="details"><input type='text' class='size form-control1'></td>
        <td class="warranty"><input type='text' class='size form-control1'></td>
        <td class="amount"><span class="item-price-amount">${formatCurrency(amount)}</span></td>
        <td class="delete"><button type="button" class="btn btn-remove-row-itemlist"><i class='bx bx-trash'></i></button></td>
    `;

    itemListTableBody.appendChild(newRow);

    const newItemDropdown = newRow.querySelector('.wrapp.item-dropdown');
    if (window.setupItemDropdown && newItemDropdown) {
        window.setupItemDropdown(newItemDropdown);
    }

    const qtyInput = newRow.querySelector('.qty input');
    const priceInput = newRow.querySelector('.price input');

    if (qtyInput && priceInput) {
        qtyInput.addEventListener('input', function () {
            window.updateRowAmount(this);
            syncAddOnQtyWithMainItem(newRow);
        });

        priceInput.addEventListener('input', function () {
            window.updateRowAmount(this);
        });
    }

    const removeBtn = newRow.querySelector('.btn-remove-row-itemlist');
    if (removeBtn) {
        removeBtn.addEventListener('click', function () {
            newRow.remove();
            window.renumberItemListTable();
            window.updateItemListTotal();
        });
    }

    if (window.updateItemListTotal) {
        window.updateItemListTotal();
    }
}

// Di dalam file wwwroot/js/site.js

function addToRequestPurchasing(itemData) {
    const reqTableBody = document.getElementById('reqTableBody');
    if (!reqTableBody) return;

    const newIndex = reqTableBody.querySelectorAll('tr').length;

    // --- MEMBUAT OPSI UNTUK DROPDOWN PIC ---
    let picOptionsHtml = '<option value="">--Pilih PIC--</option>'; // Opsi default
    if (typeof purchasingUsersFromServer !== 'undefined') {
        purchasingUsersFromServer.forEach(user => {
            picOptionsHtml += `<option value="${user.value}">${user.text}</option>`;
        });
    }
    // --- AKHIR BAGIAN PEMBUATAN OPSI ---

    const newRow = document.createElement('tr');
    newRow.innerHTML = `
        <td class="action">
            <button type="button" class="btn"><i class='bx bx-plus text-black' style="border: 2px solid #000; border-radius: 3px;"></i></button>
        </td>
        <td class="nomor text-center" style="font-weight: 500;">${newIndex + 1}</td>
        <td class="reqCode">None</td>
        <td class="name"><input type="text" class="size form-control1" name="PurchasingRequestSectionItems[${newIndex}].RequestedItemName" value="${itemData.name}" readonly></td>
        <td class="desc"><input type="text" class="size form-control1" name="PurchasingRequestSectionItems[${newIndex}].RequestedItemDescription" value="${itemData.description}" readonly></td>
        <td class="qty"><input type="number" class="size text-center form-control1" name="PurchasingRequestSectionItems[${newIndex}].Quantity" value="${itemData.quantity}"></td>
        <td class="uom"><input type="text" class="size form-control1" name="PurchasingRequestSectionItems[${newIndex}].UoM" value="${itemData.uom}"></td>
        <td class="reason"><input type="text" class="size form-control1" name="PurchasingRequestSectionItems[${newIndex}].ReasonForRequest" value="${itemData.reason}"></td>
        <td class="notes"><input type="text" class="size form-control1" name="PurchasingRequestSectionItems[${newIndex}].SalesNotes" value="${itemData.notes}"></td>
        
        <td class="pic">
            <select class="form-select size" name="PurchasingRequestSectionItems[${newIndex}].AssignedToPurchasingUserID">
                ${picOptionsHtml}
            </select>
        </td>
        <td class="reqStatus">
            <div class="d-flex justify-content-center align-items-center flex-column gap-1"><span id="not-yet" class="rounded-pill status">Not Yet</span></div>
        </td>
        <td class="delete"><button type="button" class="btn btn-remove-row-req"><i class='bx bx-trash'></i></button></td>
    `;

    reqTableBody.appendChild(newRow);
}

function isMeetingRowEmpty(row) {
    const meetingName = row.querySelector('.meeting-name input')?.value.trim();
    const picChecked = row.querySelectorAll('.meeting-pic-dropdown .survey-list-checkboxes:checked').length > 0;
    const customerPic = row.querySelector('.meeting-customer-pic input')?.value.trim();
    const reqDateTime = row.querySelector('.meeting-req-date-time input')?.value.trim();
    const detailLocation = row.querySelector('.meeting-detail-location input')?.value.trim();
    const notes = row.querySelector('.meeting-notes input')?.value.trim();

    return !meetingName && !picChecked && !customerPic && !reqDateTime && !detailLocation && !notes;
}

window.currentCompanyIsNew = false;
window.lastActiveItemDropdown = null;

/*window.items = [
    "Hikvision CCTV", "Arm Chair", "Printer Zebra", "Scanner CK-96",
    "Raspberry Pi 3", "RFID Scanner", "Raspberry Pi 4", "Raspberry Pi 5",
    "Raspberry Pi 6", "Barcode Scanner Zebra MC9300", "Barcode Scanner Datalogic Skorpio X5", "Barcode Scanner Cognex MX-1502",
    "Barcode Scanner Intermec CN80", "Barcode Scanner Janam XT200", "Barcode Scanner CK65-LON-BSC210A", "Barcode Scanner CK65-LON-BSC210E",
    "Barcode Scanner CK65-LON-BSC210F", "Barcode Scanner CK65-LON-BSC210G", "Barcode Scanner CK65-LON-BSC210H", "Dell Latitude 5430",
    "Dell Alienware Aurora", "Dell Chromebook 11", "Dell G3 15", "Dell Inspiron 14",
    "Dell Latitude 5400", "Dell Latitude 5430", "Dell Latitude 7420", "Dell Latitude 7320",
    "Dell Latitude 5520", "Dell Latitude 9420", "Dell OptiPlex 5000", "Dell OptiPlex 7080",
    "Dell OptiPlex 3080 (EOL)", "Dell OptiPlex 7070", "Dell OptiPlex 5070 (EOS)", "Samsung Galaxy S23",
    "Dell XPS 13", "Google Nest Audio", "Dell Ultra 27 Monitor", "Samsung Galaxy S23",
    "Samsung Galaxy Watch", "Sonos One", "Surface Laptop", "Sony Xperia 5 IV",
    "SolidWorks", "Sony SmartWatch 3", "Acer Predator Helios 300", "Adobe Photoshop",
    "Amazon Echo", "ASUS ROG Strix Scar 17", "Apple TV 4K", "Apple Watch Series 8",
    "Apple Watch SE", "Apple Pencil", "Arm Cortex-A78", "Aruba Instant On AP22",
    "Arduino Uno", "ARKit", "Arlo Pro 1", "Arlo Pro 2",
    "Arlo Pro 3", "Arlo Pro 4"
];*/

window.companies = [
    "PT. Accenture", "PT. Adhya Tirta Batam", "PT. Agiva Indonesia", "PT. Air Batam Hilir",
    "PT. Air Batam Hulu", "PT. Amtek Engineering Batam", "PT. Amtek Plastic Batam", "PT. Amtek Precision Components Batam",
    "PT. Angsana Bintan", "PT. Apollo Solar Indonesia", "PT. Artotel Batam", "PT. Ecogreen Oleochemicals",
    "PT. Enerco RPO Internasional", "PT. Energi Listrik Batam", "PT. EPC-M Fabricators Perkasa", "PT. EPCM SDJ Heat Exchangers"
];

const vendorData = [
    {
        name: "PT. Synnex Metrodata Indonesia",
        price: 10000000,
        validityDate: "30/07/2024",
        leadtime: "1-2 Weeks",
        location: "Batam"
    },
    {
        name: "PT. Techtitan",
        price: 9700000,
        validityDate: "30/07/2024",
        leadtime: "4-5 weeks",
        location: "Tangerang Selatan"
    },
    {
        name: "PT. Metrodata",
        price: 9800000,
        validityDate: "30/07/2024",
        leadtime: "6-8 Weeks",
        location: "Jakarta Selatan"
    },
    {
        name: "PT. Epson",
        price: 8800000,
        validityDate: "30/07/2024",
        leadtime: "8-15 Weeks",
        location: "Bogor"
    },
    {
        name: "PT. Odoo",
        price: 11800000,
        validityDate: "30/07/2024",
        leadtime: "6-12 Weeks",
        location: "Singapura"
    }
];

function setDefaultVendor() {
    const vendor = vendorData[0];
    if (!vendor) return;
    document.getElementById('vendor-name').textContent = vendor.name;
    document.getElementById('vendor-location').textContent = vendor.location;
    document.getElementById('vendor-price').textContent = formatCurrency(vendor.price);
    document.getElementById('vendor-validity').textContent = vendor.validityDate;
    document.getElementById('vendor-leadtime').textContent = vendor.leadtime;
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
    const toggler = document.querySelector("#sidebar-icon");
    const sidebar = document.getElementById('sidebar');
    const overlay = document.getElementById('sidebarOverlay');

    if (hamburger && sidebar) {
        hamburger.addEventListener("click", function () {
            // Logika untuk toggle di layar mobile (lebar <= 991.98px)
            if (window.innerWidth <= 991.98) {
                if (sidebar.classList.contains('active')) {
                    sidebar.classList.remove('active', 'expand');
                    if (overlay) overlay.classList.remove('active');
                } else {
                    sidebar.classList.add('active', 'expand');
                    if (overlay) overlay.classList.add('active');
                    sidebar.scrollTop = 0;
                }
            } else {
                // Logika untuk toggle di layar desktop
                sidebar.classList.toggle("expand");
                if (toggler) {
                    toggler.classList.toggle("bx-chevrons-right");
                    toggler.classList.toggle("bx-chevrons-left");
                }
            }
        });
    }

    // Event listener tambahan untuk overlay di mobile
    if (overlay) {
        overlay.addEventListener('click', function () {
            sidebar.classList.remove('active', 'expand');
            this.classList.remove('active');
        });
    }

    const notifBtn = document.getElementById('notifications-btn');
    const notifBar = document.getElementById('notifications-bar');
    const notifClose = document.querySelector('.notifications-close-btn');
    const notifTabs = document.querySelectorAll('.notifications-tab');
    const notifPanels = document.querySelectorAll('.notifications-panel');

    // JIKA 'notifBar' ditemukan di halaman, MAKA jalankan semua kode di dalamnya
    if (notifBar) {
        const notifBtn = document.getElementById('notifications-btn');
        const notifClose = notifBar.querySelector('.notifications-close-btn');
        const notifTabs = notifBar.querySelectorAll('.notifications-tab');
        const notifPanels = notifBar.querySelectorAll('.notifications-panel');

        if (notifBtn) {
            notifBtn.addEventListener('click', function (e) {
                notifBar.classList.add('active');
                document.body.classList.add('pop-up-active');
                document.body.classList.add('notif-bar-active');
                e.stopPropagation();
            });
        }

        if (notifClose) {
            notifClose.addEventListener('click', function () {
                notifBar.classList.remove('active');
                document.body.classList.remove('pop-up-active');
                document.body.classList.add('notif-bar-active');
            });
        }

        document.addEventListener('click', function (e) {
            if (notifBar.classList.contains('active') && !notifBar.contains(e.target) && e.target !== notifBtn) {
                notifBar.classList.remove('active');
                document.body.classList.remove('pop-up-active');
                document.body.classList.add('notif-bar-active');
            }
        });

        document.addEventListener('click', function (e) {
            if (
                e.target.matches('.notifications-panel[data-panel="reminder"] .btn') ||
                e.target.matches('.notifications-panel[data-panel="schedule"] .btn')
            ) {
                if (e.target.textContent.trim().toLowerCase() === 'clear') {
                    const card = e.target.closest('.notification-card');
                    if (card) card.remove();
                }
            }
        });

        notifTabs.forEach(tab => {
            tab.addEventListener('click', function () {
                notifTabs.forEach(t => t.classList.remove('active'));
                notifPanels.forEach(p => p.classList.remove('active'));
                this.classList.add('active');

                const activePanel = document.querySelector(`.notifications-panel[data-panel="${this.dataset.tab}"]`);
                if (activePanel) {
                    activePanel.classList.add('active');
                }
            });
        });
    }

    document.querySelectorAll('.table-sortable tbody tr').forEach(row => {
        const dateCell = row.cells[4];
        if (dateCell) {
            const raw = dateCell.textContent.trim();
            const match = raw.match(/^(\d{4}-\d{2}-\d{2})\s+(\d{2}:\d{2})-(\d{2}:\d{2})$/);
            if (match) {
                const [, dateStr, timeStart, timeEnd] = match;
                dateCell.textContent = formatRequestDateTime(dateStr, timeStart, timeEnd);
            }
        }
    });

    document.querySelectorAll('table.table-sortable tbody tr').forEach(row => {
        const totalCell = row.cells[5];
        if (totalCell) {
            const raw = totalCell.textContent.trim();
            if (/^\d+$/.test(raw)) {
                const num = parseInt(raw, 10);
                totalCell.textContent = 'Rp' + num.toLocaleString('id-ID');
            }
        }
    });

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

                if (state) {
                    sortTable(table, idx, state === 'desc');
                } else {
                    sortTable(table, idx, false);
                }
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

    document.addEventListener('click', function (e) {
        const openBtn = e.target.closest('.open-request-btn');
        if (openBtn) {
            const popup = document.querySelector('.assign-sales-form-pop-up');
            if (popup) {
                resetAssignSalesForm();
                popup.classList.add('active');
                popup.scrollTop = 0;
                document.body.classList.add('pop-up-active');
                popup.querySelectorAll('.wrapper-2').forEach(function (wrapper) {
                    initFileUpload(wrapper);
                });
                window.currentAssignRow = openBtn.closest('tr');
            }
            return;
        }

        const closeBtn = e.target.closest('#assign-sales-form-close-btn');
        if (closeBtn) {
            const popup = document.querySelector('.assign-sales-form-pop-up');
            if (popup) {
                popup.classList.remove('active');
                document.body.classList.remove('pop-up-active');
            }
            return;
        }

        const confirmBtn = e.target.closest('.assign-sales-confirm-btn');
        if (confirmBtn) {
            const row = window.currentAssignRow;
            if (!row) return;

            const adminSalesName = document.querySelector('.assign-sales-form-pop-up .admin-sales-name').value;
            if (!adminSalesName) {
                alert('Please select Admin Sales Name.');
                return;
            }

            const actionCell = row.cells[7];
            if (actionCell) {
                actionCell.innerHTML = `<div class="text-center">Assign To ${adminSalesName}</div>`;
            }

            const statusCell = row.cells[8];
            if (statusCell) {
                statusCell.innerHTML = `
                    <div class="d-flex justify-content-center align-items-center flex-column gap-1">
                        <span id="done" class="rounded-pill status">Done</span>
                    </div>
                `;
            }

            const popup = document.querySelector('.assign-sales-form-pop-up');
            if (popup) {
                popup.classList.remove('active');
                document.body.classList.remove('pop-up-active');
            }

            window.currentAssignRow = null;
        }
    });

    document.addEventListener('click', function (e) {
        const selectBtn = e.target.closest('.wrapp .select-btn');
        if (selectBtn) {
            const wrapper = selectBtn.closest('.wrapp');
            const isActive = wrapper.classList.contains('active');
            closeAllDropdowns();
            if (!isActive) {
                wrapper.classList.add('active');
            }
            e.stopPropagation();
        }
    });

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

            ['end-user', 'purchasing', 'it-engineer'].forEach(type => {
                const infoPopUp = document.querySelector(`#customer-${type}-panel .show-customer-contact-information-form-pop-up`);
                const openChevron = document.getElementById(`customer-contact-information-form-close-chevron-${type}`);
                const closeBtn = document.getElementById(`customer-contact-information-form-open-minus-${type}`);
                if (infoPopUp) infoPopUp.classList.add('active');
                if (openChevron) openChevron.style.display = 'none';
                if (closeBtn) closeBtn.style.display = 'inline-block';
            });
        });
    }

    if (closeChevron && formPopUp && addBtn) {
        closeChevron.addEventListener('click', function () {
            formPopUp.style.display = 'none';
            addBtn.style.display = 'block';
        });
    }

    ['end-user', 'purchasing', 'it-engineer'].forEach(type => {
        const panel = document.getElementById(`customer-${type}-panel`);
        if (!panel) return;

        const infoPopUp = panel.querySelector('.show-customer-contact-information-form-pop-up');
        const closeBtn = document.getElementById(`customer-contact-information-form-open-minus-${type}`);
        const openChevron = document.getElementById(`customer-contact-information-form-close-chevron-${type}`);

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
    });


    document.querySelectorAll(".add-customer-form-close-btn").forEach(btn => {
        btn.addEventListener("click", function () {
            const modal = document.querySelector(".add-customer-form-pop-up");
            if (modal) modal.classList.remove("active");
            document.body.classList.remove("pop-up-active");
            const companyWrapper = document.querySelector('.wrapp.company-dropdown');
            if (companyWrapper) {
                const companySelectBtn = companyWrapper.querySelector(".select-btn span");
                const companySearchInp = companyWrapper.querySelector("input");
                if (companySelectBtn) companySelectBtn.innerText = '';
                if (companySearchInp) companySearchInp.value = '';
                window.currentCompanyIsNew = false;
                updateCompanyStatusLabel(null);
                addCompany();
            }
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
                if (mainCompanyDropdown) {
                    mainCompanyDropdown.innerText = code ? `${companyName} (${code})` : companyName;
                    delete mainCompanyDropdown.dataset.originalName;
                }

                updateCompanyStatusLabel('not-yet');
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

        if (typeof serverSideCustomerData !== 'undefined' && serverSideCustomerData.length > 0) {
            window.companies = serverSideCustomerData.map(c => c.text);
        } else if (!window.companies) {
            // Fallback ke hardcoded list jika serverSideCustomerData tidak ada
            window.companies = [
                "PT. Accenture", "PT. Adhya Tirta Batam", "PT. Agiva Indonesia", "PT. Pelangi Fortuna Global",
                "PT. Indoshipsupply", "PT. Bintan Sukses Ancol", "PT. Citra Maritime", "PT. Bintai Kindenko Engineering Indonesia",
                "PT. Karya Abadi", "PT. Digital Solutions", "PT. Nusantara Shipping", "PT. Mandiri Sejahtera", "PT. Pertiwi",
                "PT. Megah", "PT. Maju Sejahtera", "PT. Harmoni", "PT. Prima", "PT. Sentosa", "PT. Nusantara",
                "PT. Satu", "PT. Global Investama", "PT. Intertech", "PT. Jaya Abadi"
            ];
        }

        window.addCompany = function (selectedCompany) {
            companyOptions.innerHTML = "";

            // Gunakan 'serverSideCustomerData' yang sudah berisi ID dan Nama
            if (typeof serverSideCustomerData !== 'undefined') {
                serverSideCustomerData.forEach(customer => {
                    // Bandingkan berdasarkan nama (text)
                    let isSelected = customer.text == selectedCompany ? "selected" : "";
                    let li = document.createElement("li");
                    li.textContent = customer.text;

                    // --- PERUBAHAN PENTING DIMULAI DI SINI ---
                    // Simpan CustomerID di dalam data-attribute
                    li.setAttribute('data-value', customer.value);
                    // --- AKHIR PERUBAHAN PENTING ---

                    li.className = isSelected;
                    li.onclick = function () { updateName(this); };
                    companyOptions.appendChild(li);
                });
            }
        };

        companySearchInp.addEventListener("input", () => {
            if (!companySearchInp.value.trim()) {
                window.currentCompanyIsNew = false;
                updateCompanyStatusLabel(null);
            }
        });

        function updateName(selectedLi) {
            // --- PERUBAHAN PENTING DIMULAI DI SINI ---
            const customerId = selectedLi.getAttribute('data-value');
            const customerName = selectedLi.textContent;
            const hiddenCustomerIdInput = document.getElementById('hiddenCustomerId');

            // Simpan ID yang dipilih ke input tersembunyi untuk form submission
            if (hiddenCustomerIdInput) {
                hiddenCustomerIdInput.value = customerId;
            }
            // --- AKHIR PERUBAHAN PENTING ---

            companySearchInp.value = "";
            addCompany(customerName);
            companyWrapper.classList.remove("active");
            const code = getCompanyCode(customerName);
            companySelectBtn.firstElementChild.innerText = code ? `${customerName} (${code})` : customerName;

            window.currentCompanyIsNew = false;
            updateCompanyStatusLabel(null);

            // --- PANGGIL FUNGSI AJAX DI SINI ---
            populateEndUserDropdown(customerId);
        }

        function createCompanyOption(name) {
            companyWrapper.classList.remove("active");
            companySearchInp.value = "";
            addCompany(name);
            const modal = document.querySelector(".add-customer-form-pop-up");
            if (modal) {
                resetCompanyForm(modal);
                modal.classList.add("active");
                document.body.classList.add("pop-up-active");
                modal.scrollTop = 0;
                const companyNameInput = modal.querySelector('input[placeholder="Company Name"]');
                if (companyNameInput) companyNameInput.value = name;
                window.currentCompanyIsNew = true;
                updateCompanyStatusLabel('not-yet');
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
            if (!isActive) {
                companySearchInp.value = "";
                addCompany(companySelectBtn.firstElementChild.innerText.split(' (')[0].trim());
                companyWrapper.classList.add("active");
            }
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

    window.itemWrappers = document.querySelectorAll(".wrapp.item-dropdown");

    const selectAllCheckbox = document.getElementById('select-all-item-add-on-checkbox');
    const addOnCheckboxes = document.querySelectorAll('#add-ons-table-body .add-on-checkbox');

    function triggerAddOnsAmountUpdate() {
        if (typeof window.updateAddOnsAmount === 'function') {
            window.updateAddOnsAmount();
        }
    }

    if (selectAllCheckbox) {
        selectAllCheckbox.addEventListener('change', function () {
            const isChecked = this.checked;
            addOnCheckboxes.forEach(checkbox => {
                checkbox.checked = isChecked;
            });
            triggerAddOnsAmountUpdate();
        });
    }

    addOnCheckboxes.forEach(checkbox => {
        checkbox.addEventListener('change', function () {
            const allChecked = Array.from(addOnCheckboxes).every(cb => cb.checked);
            if (selectAllCheckbox) {
                selectAllCheckbox.checked = allChecked;
            }
            triggerAddOnsAmountUpdate();
        });
    });



    function addItemOptions(wrapper, selectedItem) {
        const itemOptions = wrapper.querySelector(".option");
        itemOptions.innerHTML = "";
        // Cek apakah variabel dari server sudah ada
        if (typeof itemMasterDataFromServer !== 'undefined' && Array.isArray(itemMasterDataFromServer)) {
            // Urutkan data dari server
            itemMasterDataFromServer.sort((a, b) => a.text.localeCompare(b.text, undefined, { sensitivity: 'base' }));

            // Loop melalui data dari server, bukan window.items
            itemMasterDataFromServer.forEach(item => {
                let isSelected = item.text == selectedItem ? "selected" : "";
                let li = document.createElement("li");
                li.textContent = item.text; // Tampilkan nama item
                li.setAttribute('data-value', item.value); // SIMPAN ID ITEM DI SINI
                li.className = isSelected;
                li.onclick = function () { updateItemName(wrapper, this); };
                itemOptions.appendChild(li);
            });
        }
    }

    function updateItemName(wrapper, selectedLi) {
        const searchInp = wrapper.querySelector("input");
        const selectBtn = wrapper.querySelector(".select-btn span");
        searchInp.value = "";
        addItemOptions(wrapper, selectedLi.textContent);
        wrapper.classList.remove("active");
        selectBtn.innerText = selectedLi.textContent;
        wrapper.dataset.isNew = "false";

        if (!selectedLi.classList.contains('create-option')) {
            const itemName = selectedLi.textContent.trim();
            const configureItemForm = document.querySelector('.configure-item-form-pop-up');
            if (configureItemForm) {
                resetConfigureItemForm();
                setDefaultVendor();

                const itemNameCodeElement = document.getElementById('configure-item-name-code');
                if (itemNameCodeElement) {
                    itemNameCodeElement.textContent = `${itemName} [HWY00001]`;
                }
                const quantityInput = document.getElementById('configure-item-quantity');
                if (quantityInput) {
                    quantityInput.value = 1;
                }
                const amountElement = document.getElementById('configure-item-amount');
                const vendorPriceElement = document.getElementById('vendor-price');
                if (amountElement && vendorPriceElement) {
                    amountElement.textContent = formatCurrency(parseCurrency(vendorPriceElement.textContent));

                }
                configureItemForm.classList.add('active');
                document.body.classList.add('pop-up-active');
                configureItemForm.scrollTop = 0;
                if (typeof initConfigureItemForm === 'function') {
                    initConfigureItemForm();
                }
            }
        }
    }

    function createItemOption(wrapper, name) {
        wrapper.classList.remove("active");
        const searchInp = wrapper.querySelector("input");
        searchInp.value = "";
        window.lastActiveItemDropdown = wrapper;

        const modal = document.querySelector('.request-item-to-purchasing-form-pop-up');
        if (modal) {
            resetRequestItemToPurchasingForm();
            modal.classList.add('active');
            document.body.classList.add('pop-up-active');
            modal.scrollTop = 0;

            const itemNameInput = modal.querySelector('#request-item-name');
            if (itemNameInput) {
                itemNameInput.value = name;
                itemNameInput.focus();
            }
        }
    }

    function setupItemDropdown(wrapper) {
        const selectBtn = wrapper.querySelector(".select-btn");
        const searchInp = wrapper.querySelector("input[type='text']");
        const itemOptions = wrapper.querySelector(".option"); // This is the UL element
        const hiddenInput = wrapper.closest('td').querySelector(".item-id-hidden");

        if (!selectBtn || !searchInp || !itemOptions || !hiddenInput) {
            return;
        }

        // Use Event Delegation on the UL element.
        itemOptions.addEventListener('click', function(e) {
            const selectedLi = e.target.closest('li');
            if (!selectedLi) return;

            if (selectedLi.classList.contains('create-option')) {
                const searchWord = searchInp.value.trim();
                if (typeof createItemOption === 'function') {
                    createItemOption(wrapper, searchWord);
                }
                return;
            }

            const selectedValue = selectedLi.getAttribute('data-value');
            const selectedText = selectedLi.textContent;

            if (hiddenInput) {
                hiddenInput.value = selectedValue;
            }

            const span = selectBtn.querySelector("span");
            if (span) span.innerText = selectedText;

            wrapper.classList.remove("active");

            // RE-INTRODUCED POP-UP LOGIC
            const itemName = selectedText.trim();
            const configureItemForm = document.querySelector('.configure-item-form-pop-up');
            if (configureItemForm) {
                if (typeof resetConfigureItemForm === 'function') resetConfigureItemForm();
                if (typeof setDefaultVendor === 'function') setDefaultVendor();

                const itemNameCodeElement = document.getElementById('configure-item-name-code');
                if (itemNameCodeElement) {
                    itemNameCodeElement.textContent = `${itemName} [HWY00001]`;
                }
                const quantityInput = document.getElementById('configure-item-quantity');
                if (quantityInput) {
                    quantityInput.value = 1;
                }
                const amountElement = document.getElementById('configure-item-amount');
                const vendorPriceElement = document.getElementById('vendor-price');
                if (amountElement && vendorPriceElement && typeof formatCurrency === 'function' && typeof parseCurrency === 'function') {
                    const priceText = vendorPriceElement.textContent || '0';
                    amountElement.textContent = formatCurrency(parseCurrency(priceText));
                }

                configureItemForm.classList.add('active');
                document.body.classList.add('pop-up-active');
                configureItemForm.scrollTop = 0;
                if (typeof initConfigureItemForm === 'function') {
                    initConfigureItemForm();
                }
            }
        });

        function populateList(searchTerm = "") {
            itemOptions.innerHTML = "";
            const searchTermLower = searchTerm.toLowerCase();
            const filteredItems = (typeof itemMasterDataFromServer !== 'undefined' ? itemMasterDataFromServer : []).filter(data =>
                data.text.toLowerCase().includes(searchTermLower)
            );

            if (searchTerm) {
                const createLi = document.createElement("li");
                createLi.className = "create-option";
                createLi.textContent = `Request "${searchTerm}"`;
                itemOptions.appendChild(createLi);
            }

            filteredItems.forEach(item => {
                const li = document.createElement("li");
                li.textContent = item.text;
                li.setAttribute('data-value', item.value);
                itemOptions.appendChild(li);
            });
        }

        searchInp.addEventListener("keyup", () => populateList(searchInp.value.trim()));

        selectBtn.addEventListener("click", function (e) {
            e.stopPropagation();
            const isActive = wrapper.classList.contains("active");
            closeAllDropdowns();
            if (!isActive) {
                searchInp.value = "";
                populateList();
                wrapper.classList.add("active");
                searchInp.focus();
            }
        });
    }

    document.querySelectorAll(".wrapp.item-dropdown").forEach(setupItemDropdown);

    document.querySelectorAll('.request-item-to-purchasing-form-close-btn, .request-item-to-purchasing-form-cancel-btn').forEach(btn => {
        btn.addEventListener('click', function () {
            const modal = document.querySelector('.request-item-to-purchasing-form-pop-up');
            modal.classList.remove('active');
            document.body.classList.remove('pop-up-active');
            if (window.lastActiveItemDropdown) {
                const selectBtn = window.lastActiveItemDropdown.querySelector(".select-btn span");
                const searchInp = window.lastActiveItemDropdown.querySelector("input");
                if (selectBtn) selectBtn.innerText = '';
                if (searchInp) searchInp.value = '';
                addItemOptions(window.lastActiveItemDropdown);
                window.lastActiveItemDropdown = null;
            }
            const itemNameInput = modal.querySelector('#request-item-name');
            if (itemNameInput) itemNameInput.value = '';
        });
    });

    document.querySelectorAll('.request-item-to-purchasing-form-save-btn').forEach(btn => {
        btn.addEventListener('click', function (e) {
            e.preventDefault(); // Mencegah form submit default

            const modal = this.closest('.request-item-to-purchasing-form-pop-up');

            // 1. Ambil semua data dari form di pop-up
            const name = modal.querySelector('#request-item-name').value.trim();
            const desc = modal.querySelector('#request-item-desc').value.trim();
            const qty = modal.querySelector('#request-item-qty').value.trim();
            const uom = modal.querySelector('#request-item-uom').value.trim();
            const detail = modal.querySelector('#request-item-detail').value.trim();

            if (!name) return; // Jangan lakukan apa-apa jika nama kosong

            // 2. Panggil fungsi addToRequestPurchasing yang sudah kita perbaiki sebelumnya
            // Fungsi ini sudah bisa membuat dropdown PIC dengan benar.
            addToRequestPurchasing({
                name: name,
                description: desc,
                quantity: qty,
                uom: uom,
                reason: "Not yet in the Database", // Alasan default untuk item baru
                notes: detail
            });

            // 3. Reset dan tutup pop-up
            if (modal) {
                resetRequestItemToPurchasingForm();
                modal.classList.remove('active');
                document.body.classList.remove('pop-up-active');
            }
        });
    });

    const resourceWrapper = document.querySelector('.wrapp.resource-dropdown');
    if (resourceWrapper) {
        const resourceSelectBtnText = resourceWrapper.querySelector('.select-btn span');
        const resourceHiddenInput = document.querySelector('input[name="Resource"]');
        const personalResourceHiddenInput = document.querySelector('input[name="PersonalResourceEmployeeID"]');

        // Menggunakan satu event listener utama pada wrapper
        resourceWrapper.addEventListener('click', function (e) {
            const clickedLi = e.target.closest('li');
            if (!clickedLi || !this.classList.contains('active')) return;

            // Cek jika yang diklik adalah header sub-menu (seperti "Email", "Phone")
            if (clickedLi.classList.contains('has-sub')) {
                e.stopPropagation(); // Mencegah dropdown utama tertutup
                clickedLi.classList.toggle('active'); // Buka/tutup sub-menu
                return; // Hentikan eksekusi, jangan pilih nilai apapun
            }

            // Jika kita sampai di sini, artinya sebuah nilai akhir telah diklik
            const selectedText = clickedLi.innerText.trim();
            let finalValue = selectedText;

            // Reset ID personal resource
            if (personalResourceHiddenInput) personalResourceHiddenInput.value = '';

            // Cek apakah yang diklik ada di dalam sub-menu "Personal"
            const personalParent = clickedLi.closest('#resource-personal-sub-dropdown');
            if (personalParent) {
                const subType = clickedLi.closest('.has-sub').firstChild.textContent.trim(); // Mendapatkan "Email", "Phone", dll.
                finalValue = `Personal ${subType} (${selectedText})`;

                // Simpan ID user ke hidden input khusus Personal Resource
                if (personalResourceHiddenInput) {
                    personalResourceHiddenInput.value = clickedLi.getAttribute('data-value');
                }
            }

            // Update tampilan teks dan nilai di hidden input utama
            if (resourceSelectBtnText) resourceSelectBtnText.innerText = finalValue;
            if (resourceHiddenInput) resourceHiddenInput.value = finalValue;

            // Tutup semua dropdown
            closeAllDropdowns();
        });
    }

    (function patchCompanyDropdown() {
        const companyWrapper = document.querySelector('.wrapp.company-dropdown');
        if (!companyWrapper) return;
        const companySpan = companyWrapper.querySelector('.select-btn span');
        const companyOptions = companyWrapper.querySelector('.option');
        if (!companySpan || !companyOptions) return;

        companyOptions.addEventListener('click', function (e) {
            if (e.target.tagName === 'LI') {
                companySpan.dataset.originalName = e.target.textContent.trim();
                setTimeout(updateCompanyNameDisplay, 50);
            }
        });
    })();

    (function patchResourceDropdown() {
        const resourceWrapper = document.querySelector('.wrapp.resource-dropdown');
        if (!resourceWrapper) return;
        const resourceOptions = resourceWrapper.querySelectorAll('.option > li:not(.has-sub)');
        const personalOptions = resourceWrapper.querySelectorAll('#resource-personal-sub-dropdown li');

        resourceOptions.forEach(option => {
            option.addEventListener('click', function () {
                setTimeout(updateCompanyNameDisplay, 50);
            });
        });
        personalOptions.forEach(option => {
            option.addEventListener('click', function () {
                setTimeout(updateCompanyNameDisplay, 50);
            });
        });
    })();

    document.addEventListener('DOMContentLoaded', updateCompanyNameDisplay);

    const projectTypeWrapper = document.querySelector('.wrapp.project-type-dropdown');
    if (projectTypeWrapper) {
        const projectTypeSelectBtnText = projectTypeWrapper.querySelector('.select-btn span');
        const projectTypeHiddenInput = document.querySelector('input[name="RFQCategoryID"]'); // Temukan hidden input berdasarkan 'name'
        const projectTypeOptions = projectTypeWrapper.querySelectorAll('.option li');

        projectTypeOptions.forEach(option => {
            option.addEventListener('click', function (e) {
                e.stopPropagation();

                // Ambil data dari elemen yang diklik
                const selectedText = this.innerText;
                const selectedValue = this.getAttribute('data-value');

                // 1. Perbarui teks yang ditampilkan
                if (projectTypeSelectBtnText) {
                    projectTypeSelectBtnText.innerText = selectedText;
                }

                // 2. (INI BAGIAN PENTING) Perbarui nilai di hidden input
                if (projectTypeHiddenInput) {
                    projectTypeHiddenInput.value = selectedValue;
                }

                // 3. Tutup dropdown
                projectTypeWrapper.classList.remove("active");
            });
        });

        // Event untuk membuka dropdown (biarkan seperti yang sudah ada)
        projectTypeWrapper.querySelector('.select-btn').addEventListener('click', function (e) {
            e.stopPropagation();
            const isActive = projectTypeWrapper.classList.contains('active');
            closeAllDropdowns();
            if (!isActive) {
                projectTypeWrapper.classList.add("active");
            }
        });
    }

    const opportunityWrapper = document.getElementById('opportunity-dropdown');
    if (opportunityWrapper) {
        const opportunitySelectBtnText = opportunityWrapper.querySelector('.select-btn span');
        const opportunityHiddenInput = document.querySelector('input[name="RFQOpportunityID"]'); // Temukan hidden input berdasarkan 'name'
        const opportunityOptions = opportunityWrapper.querySelectorAll('.option li');

        opportunityOptions.forEach(option => {
            option.addEventListener('click', function (e) {
                e.stopPropagation();

                // Ambil data dari elemen yang diklik
                const selectedText = this.innerText;
                const selectedValue = this.getAttribute('data-value');

                // 1. Perbarui teks yang ditampilkan
                if (opportunitySelectBtnText) {
                    opportunitySelectBtnText.innerText = selectedText;
                }

                // 2. (INI BAGIAN PENTING) Perbarui nilai di hidden input
                if (opportunityHiddenInput) {
                    opportunityHiddenInput.value = selectedValue;
                }

                // 3. Tutup dropdown
                opportunityWrapper.classList.remove("active");
            });
        });

        // Event untuk membuka dropdown (biarkan seperti yang sudah ada)
        opportunityWrapper.querySelector('.select-btn').addEventListener('click', function (e) {
            e.stopPropagation();
            const isActive = opportunityWrapper.classList.contains("active");
            closeAllDropdowns();
            if (!isActive) {
                opportunityWrapper.classList.add("active");
            }
        });
    }

    document.addEventListener('click', function (e) {
        if (!e.target.closest('.wrapp')) {
            closeAllDropdowns();
        }
    });

    document.querySelectorAll('#itemListTableBody input').forEach(input => {
        input.addEventListener('input', function () {
            updateAddItemButtonState();
        });
    });

    document.querySelectorAll('#itemListTableBody .wrapp.item-dropdown .select-btn').forEach(btn => {
        btn.addEventListener('click', function () {
            setTimeout(updateAddItemButtonState, 100);
        });
    });

    updateAddItemButtonState();

    renumberTableRows('itemTableBody');
    renumberItemListTable();

    renumberReqTable();

    document.querySelectorAll('#itemListTableBody tr:not(.addon-row) .qty input').forEach(input => {
        input.addEventListener('input', function () {
            const mainRow = this.closest('tr');
            syncAddOnQtyWithMainItem(mainRow);
        });
    });

    document.querySelectorAll('#itemListTableBody .btn-remove-row-itemlist').forEach(btn => {
        btn.addEventListener('click', function () {
            const row = this.closest('tr');
            if (row) {
                if (!row.classList.contains('addon-row')) {
                    let next = row.nextElementSibling;
                    while (next && next.classList.contains('addon-row')) {
                        const toRemove = next;
                        next = next.nextElementSibling;
                        toRemove.parentNode.removeChild(toRemove);
                    }
                }
                row.parentNode.removeChild(row);
                renumberItemListTable();
                updateItemListTotal();
                updateAddItemButtonState();
            }
        });
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

    document.addEventListener('click', function (e) {
        const btn = e.target.closest('.wrapp .select-btn');
        if (btn && btn.closest('.wrapp').classList.contains('disabled-by-script')) {
            e.stopPropagation();
            e.preventDefault();
        }
    }, true);

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
            const rowCount = itemTableBody.children.length + 1; // Nomor baris berikutnya
            const newRow = document.createElement('tr');
            newRow.innerHTML = `
                <td>${rowCount}</td>
                <td class="name"><input type='text' class='size form-control1' name="NotesSectionItems[${rowCount - 1}].ItemName"></td>
                <td class="desc"><input type='text' class='size form-control1' name="NotesSectionItems[${rowCount - 1}].ItemDescription"></td>
                <td class="qty"><input type='number' class='size form-control1' name="NotesSectionItems[${rowCount - 1}].Quantity" value="1"></td>
                <td class="uom"><input type='text' class='size tengah form-control1' name="NotesSectionItems[${rowCount - 1}].UoM" value="Unit"></td>
                <td class="budget"><input type='number' class='size form-control1' name="NotesSectionItems[${rowCount - 1}].BudgetTarget"></td>
                <td class="leadtime"><input type='text' class='size tengah form-control1' name="NotesSectionItems[${rowCount - 1}].LeadTimeTarget"></td>
                <td class="delete"><button type="button" onclick="removeRow(this)" class="btn"><i class='bx bx-trash'></i></button></td>
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
    if (addRowBtnItem) {
        addRowBtnItem.addEventListener('click', function () {
            const tbody = document.getElementById('itemListTableBody');
            // Dapatkan indeks untuk baris baru SEBELUM baris ditambahkan
            const newIndex = tbody.querySelectorAll('tr').length;
            const newRow = document.createElement('tr');


            newRow.innerHTML = `
            <td class="text-center" style="font-weight: 500;">${newIndex + 1}</td>
            <td class="name">
                <input type="hidden" name="ItemListSectionItems[${newIndex}].ItemID" value="" class="item-id-hidden">
                <div class="wrapp item-dropdown" style="width: 100%;">
                    <div class="select-btn d-flex align-items-center">
                        <span></span>
                        <i class='bx bx-chevron-down'></i>
                    </div>
                    <div class="content-search">
                        <div class="search">
                            <i class="bx bx-search-alt-2"></i>
                            <input type="text" placeholder="Search" />
                        </div>
                        <ul class="option" style="margin-bottom: 10px;"></ul>
                    </div>
                </div>
            </td>
            <td class="desc"><input type='text' class='size form-control1' name="ItemListSectionItems[${newIndex}].ItemDescription"></td>
            <td class="qty"><input type='number' class='size text-center form-control1' name="ItemListSectionItems[${newIndex}].Quantity" oninput="updateRowAmount(this)"></td>
            <td class="uom"><input type='text' class='size form-control1' name="ItemListSectionItems[${newIndex}].UoM"></td>
            <td class="price"><input type='number' class='size form-control1' name="ItemListSectionItems[${newIndex}].TargetUnitPrice" oninput="updateRowAmount(this)"></td>
            <td class="notes"><input type='text' class='size form-control1' name="ItemListSectionItems[${newIndex}].Notes"></td>
            <td class="details"><input type='text' class='size form-control1' name="ItemListSectionItems[${newIndex}].Details"></td>
            <td class="warranty"><input type='text' class='size form-control1' name="ItemListSectionItems[${newIndex}].SalesWarranty"></td>
            <td class="amount"><span class="item-price-amount"></span></td>
            <td class="delete"><button type="button" class="btn btn-remove-row-itemlist"><i class='bx bx-trash'></i></button></td>
        `;

            tbody.appendChild(newRow);
            renumberItemListTable();

            setupItemDropdown(newRow.querySelector('.wrapp.item-dropdown'));

            newRow.querySelectorAll('input').forEach(input => {
                input.addEventListener('input', function () {
                    updateAddItemButtonState();
                });
            });

            const selectBtn = newRow.querySelector('.select-btn');
            if (selectBtn) {
                selectBtn.addEventListener('click', function () {
                    setTimeout(updateAddItemButtonState, 100);
                });
            }

            updateAddItemButtonState();
        });

        updateAddItemButtonState();
    }

    function recalculateTotal() {
        updateItemListTotal();
    }
    const itemListTableBody = document.getElementById('itemListTableBody');
    if (itemListTableBody) {
        itemListTableBody.addEventListener('click', function (e) {
            if (e.target.closest('.btn-remove-row-itemlist')) {
                const row = e.target.closest('tr');
                if (row) {
                    if (!row.classList.contains('addon-row')) {
                        let next = row.nextElementSibling;
                        while (next && next.classList.contains('addon-row')) {
                            const toRemove = next;
                            next = next.nextElementSibling;
                            toRemove.parentNode.removeChild(toRemove);
                        }
                    }
                    itemListTableBody.removeChild(row);
                    renumberItemListTable();
                    updateItemListTotal();
                    updateAddItemButtonState();
                }
            }
        });

        itemListTableBody.addEventListener('input', function (e) {
            const input = e.target;
            if (input.closest('td.qty') || input.closest('td.price')) {
                updateRowAmount(input);
            }

            updateAddItemButtonState();
        });
    }

    recalculateTotal();

    document.querySelectorAll('#itemListTableBody .qty input, #itemListTableBody .price input').forEach(input => {
        input.addEventListener('input', function () {
            updateRowAmount(this);
        });
    });

    document.querySelectorAll('#itemListTableBody input').forEach(input => {
        input.addEventListener('input', function () {
            updateAddItemButtonState();
        });
    });

    document.querySelectorAll('#itemListTableBody .wrapp.item-dropdown .select-btn').forEach(btn => {
        btn.addEventListener('click', function () {
            setTimeout(updateAddItemButtonState, 100);
        });
    });

    updateAddItemButtonState();

    document.querySelectorAll('#itemListTableBody tr').forEach(row => {
        const qtyInput = row.querySelector('.qty input');
        if (qtyInput) updateRowAmount(qtyInput);
    });

    const reqTableBody = document.getElementById('reqTableBody');
    if (reqTableBody) {
        reqTableBody.addEventListener('click', function (e) {
            if (e.target.closest('.bx-plus')) {
                const row = e.target.closest('tr');
                if (!row) return;

                // 1. Ambil data dari baris "Request Item to Purchasing" yang di-klik
                const name = row.querySelector('td.name input')?.value.trim();
                const desc = row.querySelector('td.desc input')?.value.trim();
                const qty = row.querySelector('td.qty input')?.value.trim();
                const uom = row.querySelector('td.uom input')?.value.trim();

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
                    const newIndex = itemListTbody.querySelectorAll('tr').length;
                    targetRow = document.createElement('tr');
                    targetRow.innerHTML = `
           <td class="text-center" style="font-weight: 500;">${newIndex + 1}</td>
            <td class="name">
                <input type="hidden" name="ItemListSectionItems[${newIndex}].ItemID" value="">
                <div class="wrapp item-dropdown" style="width: 100%;">
                    <div class="select-btn d-flex align-items-center">
                        <span>${name}</span>
                        <i class='bx bx-chevron-down'></i>
                    </div>
                    <div class="content-search">
                        <div class="search"><i class="bx bx-search-alt-2"></i><input type="text" placeholder="Search"></div>
                        <ul class="option" style="margin-bottom: 10px;"></ul>
                    </div>
                </div>
            </td>
            <td class="desc"><input type="text" class="size form-control1" name="ItemListSectionItems[${newIndex}].ItemDescription" value="${desc}"></td>
            <td class="qty"><input type="number" class="size text-center form-control1" name="ItemListSectionItems[${newIndex}].Quantity" value="${qty}" oninput="updateRowAmount(this)"></td>
            <td class="uom"><input type="text" class="size form-control1" name="ItemListSectionItems[${newIndex}].UoM" value="${uom}"></td>
            <td class="price"><input type="number" class="size form-control1" name="ItemListSectionItems[${newIndex}].TargetUnitPrice" oninput="updateRowAmount(this)"></td>
            <td class="notes"><input type="text" class="size form-control1" name="ItemListSectionItems[${newIndex}].Notes"></td>
            <td class="details"><input type="text" class="size form-control1" name="ItemListSectionItems[${newIndex}].Details"></td>
            <td class="warranty"><input type="text" class="size form-control1" name="ItemListSectionItems[${newIndex}].SalesWarranty"></td>
            <td class="amount"><span class="item-price-amount"></span></td>
            <td class="delete"><button type="button" class="btn btn-remove-row-itemlist"><i class="bx bx-trash"></i></button></td>
        `;

                    // 4. Tambahkan baris baru ke tabel "Item List"
                    itemListTbody.appendChild(targetRow);

                    setupItemDropdown(targetRow.querySelector('.wrapp.item-dropdown'));
                }

                const nameDropdown = targetRow.querySelector('.name .select-btn span');
                if (nameDropdown) nameDropdown.textContent = name;
                targetRow.querySelector('td.desc input').value = desc;
                targetRow.querySelector('td.qty input').value = qty;
                targetRow.querySelector('td.uom input').value = uom;
                updateRowAmount(targetRow.querySelector('td.qty input'));

                const itemDropdown = targetRow.querySelector('.wrapp.item-dropdown');
                if (itemDropdown) {
                    itemDropdown.classList.add('disabled-by-script');
                    itemDropdown.setAttribute('tabindex', '-1');
                }

                let next = row.nextElementSibling;
                let insertAfter = targetRow;
                while (next && next.classList.contains('addon-row')) {
                    const addOnRow = next;
                    next = next.nextElementSibling;

                    const addOnName = addOnRow.querySelector('td.name input').value.trim();
                    const addOnDesc = addOnRow.querySelector('td.desc input').value.trim();
                    const addOnQty = addOnRow.querySelector('td.qty input').value.trim();
                    const addOnUom = addOnRow.querySelector('td.uom input').value.trim();
                    const addOnPrice = addOnRow.querySelector('td.price input')?.value.trim() || 0;


                    const newAddOnRow = document.createElement('tr');
                    newAddOnRow.classList.add('addon-row');
                    const newAddonIndex = itemListTbody.querySelectorAll('tr').length;
                    newAddOnRow.innerHTML = `
                    <td></td>
                    <td class="name">
                        <input type="hidden" name="ItemListSectionItems[${newAddonIndex}].ItemID" value="">
                        <div class="wrapp item-dropdown" style="width: 100%;">
                            <div class="select-btn d-flex align-items-center">
                                <span>${addOnName}</span><i class='bx bx-chevron-down'></i>
                            </div>
                            <div class="content-search">
                                <div class="search"><i class="bx bx-search-alt-2"></i><input type="text" placeholder="Search" /></div>
                                <ul class="option" style="margin-bottom: 10px;"></ul>
                            </div>
                        </div>
                    </td>
                    <td class="desc"><input type='text' class='size form-control1' name="ItemListSectionItems[${newAddonIndex}].ItemDescription" value="${addOnDesc}"></td>
                    <td class="qty"><input type='number' class='size text-center form-control1' name="ItemListSectionItems[${newAddonIndex}].Quantity" value="${addOnQty}"></td>
                    <td class="uom"><input type='text' class='size form-control1' name="ItemListSectionItems[${newAddonIndex}].UoM" value="${addOnUom}"></td>
                    <td class="price"><input type='number' class='size form-control1' name="ItemListSectionItems[${newAddonIndex}].TargetUnitPrice"></td>
                    <td class="notes"><input type='text' class='size form-control1' name="ItemListSectionItems[${newAddonIndex}].Notes"></td>
                    <td class="details"><input type='text' class='size form-control1' name="ItemListSectionItems[${newAddonIndex}].Details"></td>
                    <td class="warranty"><input type='text' class='size form-control1' name="ItemListSectionItems[${newAddonIndex}].SalesWarranty"></td>
                    <td class="amount"><span class="item-price-amount"></span></td>
                    <td class="delete"><button type="button" class="btn btn-remove-row-itemlist"><i class='bx bx-trash'></i></button></td>
                `;

                    if (insertAfter && insertAfter.nextSibling) {
                        itemListTbody.insertBefore(newAddOnRow, insertAfter.nextSibling);
                    } else {
                        itemListTbody.appendChild(newAddOnRow);
                    }
                    insertAfter = newAddOnRow;

                    setupItemDropdown(newAddOnRow.querySelector('.wrapp.item-dropdown'));
                    const addOnDropdown = newAddOnRow.querySelector('.wrapp.item-dropdown');
                    if (addOnDropdown) {
                        addOnDropdown.classList.add('disabled-by-script');
                        addOnDropdown.setAttribute('tabindex', '-1');
                    }
                    newAddOnRow.querySelectorAll('input').forEach(input => {
                        input.addEventListener('input', function () {
                            updateAddItemButtonState();
                        });
                    });
                    const selectBtn = newAddOnRow.querySelector('.select-btn');
                    if (selectBtn) {
                        selectBtn.addEventListener('click', function () {
                            setTimeout(updateAddItemButtonState, 100);
                        });
                    }
                    const deleteBtn = newAddOnRow.querySelector('.btn-remove-row-itemlist');
                    deleteBtn.addEventListener('click', function () {
                        newAddOnRow.remove();
                        renumberItemListTable();
                        updateItemListTotal();
                        updateAddItemButtonState();
                    });

                    updateRowAmount(newAddOnRow.querySelector('.qty input'));

                    addOnRow.parentNode.removeChild(addOnRow);
                }



                row.parentNode.removeChild(row);
                renumberItemListTable();
                renumberReqTable();
                updateAddItemButtonState();
            }
        });
    }
    function initFileUpload(wrapper) {
        if (!wrapper.uploadedFiles) wrapper.uploadedFiles = [];

        const formUpload = wrapper.querySelector('.form-upload');
        const fileInput = wrapper.querySelector(".file-input");
        const attachedFilesContainer = wrapper.querySelector('#attached-files');
        const attachmentCount = wrapper.querySelector('.attachment-count');

        if (!formUpload || !fileInput || !attachedFilesContainer || !attachmentCount) return;

        function renderFiles() {
            attachedFilesContainer.innerHTML = '';
            wrapper.uploadedFiles.forEach((file, idx) => {
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
                            <span class="name">${formatFileName(file.name)}</span>
                            <span class="size">${fileSize}</span>
                        </div>
                        <div class="button-function">
                            <button type="button" class="delete-button float-end me-1"><i class="fas fa-times"></i></button>
                            <button type="button" class="download-button float-end me-2"><i class="fas fa-download"></i></button> 
                        </div>
                    </div>
                `;

                fileInfo.querySelector('.download-button').addEventListener('click', () => {
                    const url = URL.createObjectURL(file);
                    const a = document.createElement('a');
                    a.href = url;
                    a.download = file.name;
                    document.body.appendChild(a);
                    a.click();
                    document.body.removeChild(a);
                    URL.revokeObjectURL(url);
                });

                fileInfo.querySelector('.delete-button').addEventListener('click', () => {
                    wrapper.uploadedFiles.splice(idx, 1);
                    renderFiles();
                    updateCount();
                });

                attachedFilesContainer.appendChild(fileInfo);
            });
            updateCount();
        }

        function updateCount() {
            attachmentCount.textContent = wrapper.uploadedFiles.length;
            attachedFilesContainer.style.display = wrapper.uploadedFiles.length > 0 ? 'block' : 'none';
        }

        function handleDroppedFiles(files) {
            const currentCount = wrapper.uploadedFiles.length;
            if (currentCount >= 5) {
                alert('You can only upload a maximum of 5 files.');
                return;
            }
            const newFiles = Array.from(files);
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

            validFiles.forEach((file) => {
                wrapper.uploadedFiles.push(file);
            });
            renderFiles();
        }

        formUpload.onclick = null;
        fileInput.onchange = null;
        formUpload.ondragover = null;
        formUpload.ondragleave = null;
        formUpload.ondrop = null;

        formUpload.addEventListener("click", function (e) {
            if (e.target === fileInput) return;
            if (wrapper.uploadedFiles.length >= 5) {
                alert('You can only upload a maximum of 5 files.');
                return;
            }
            fileInput.click();
        });

        fileInput.addEventListener('change', function () {
            const files = this.files;
            if (files && files.length > 0) {
                handleDroppedFiles(files);
            }
            this.value = '';
        });

        formUpload.addEventListener('dragover', function (e) {
            e.preventDefault();
            e.stopPropagation();
            if (!formUpload.classList.contains('disabled-by-script') &&
                !formUpload.hasAttribute('disabled')) {
                formUpload.classList.add('active');
            }
        });

        formUpload.addEventListener('dragleave', function (e) {
            e.preventDefault();
            e.stopPropagation();
            formUpload.classList.remove('active');
        });

        formUpload.addEventListener('drop', function (e) {
            e.preventDefault();
            e.stopPropagation();
            formUpload.classList.remove('active');
            if (formUpload.classList.contains('disabled-by-script') ||
                formUpload.hasAttribute('disabled') ||
                fileInput.hasAttribute('disabled')) {
                return;
            }
            const files = e.dataTransfer.files;
            if (files && files.length > 0) {
                handleDroppedFiles(files);
            }
        });

        renderFiles();
    }

    document.querySelectorAll('.wrapper-2').forEach(function (wrapper) {
        initFileUpload(wrapper);
    });

    document.getElementById('itemTableBody').addEventListener('click', function (e) {
        if (e.target.closest('.btn-remove-row')) {
            const row = e.target.closest('tr');
            if (row) this.removeChild(row);
            Array.from(this.children).forEach((tr, i) => {
                tr.querySelector('td').innerText = i + 1;
            });
        }
    });

    document.getElementById('itemListTableBody').addEventListener('click', function (e) {
        if (e.target.closest('.btn-remove-row-itemlist')) {
            const row = e.target.closest('tr');
            if (row) this.removeChild(row);
            Array.from(this.children).forEach((tr, i) => {
                tr.querySelector('td').innerText = i + 1;
            });
        }
    });

    document.getElementById('reqTableBody').addEventListener('click', function (e) {
        if (e.target.closest('.btn-remove-row-req')) {
            const row = e.target.closest('tr');
            if (row) {
                if (!row.classList.contains('addon-row')) {
                    let next = row.nextElementSibling;
                    while (next && next.classList.contains('addon-row')) {
                        let toRemove = next;
                        next = next.nextElementSibling;
                        toRemove.parentNode.removeChild(toRemove);
                    }
                }
                row.parentNode.removeChild(row);
                renumberReqTable();
            }
        }
    });

    function updateAmount(row) {
        const qtyInput = row.querySelector('td.qty input');
        const priceInput = row.querySelector('td.price input');
        const amountSpan = row.querySelector('td.amount span');
        const qty = parseFloat(qtyInput.value) || 0;
        const price = parseFloat(priceInput.value) || 0;
        const amount = qty * price;
        amountSpan.textContent = amount ? amount.toLocaleString('id-ID') : '';
    }

    function updateAllAmounts() {
        const rows = document.querySelectorAll('#itemListTableBody tr');
        rows.forEach(row => updateAmount(row));
        let total = 0;
        rows.forEach(row => {
            const amountSpan = row.querySelector('td.amount span');
            const amount = parseFloat(amountSpan.textContent.replace(/\./g, '').replace(/,/g, '.')) || 0;
            total += amount;
        });
        const totalBox = document.querySelector('#itemListTotalBox .total-value');
        if (totalBox) totalBox.textContent = 'Rp' + total.toLocaleString('id-ID');
    }

    document.getElementById('itemListTableBody').addEventListener('input', function (e) {
        if (e.target.matches('td.qty input') || e.target.matches('td.price input')) {
            const row = e.target.closest('tr');
            updateAmount(row);
            updateAllAmounts();
        }
    });

    updateAllAmounts();

    const reasonSelect = document.getElementById('reason-for-request');
    const otherReasonContainer = document.getElementById('other-reason-container');
    const otherReasonInput = document.getElementById('other-reason-input');

    if (reasonSelect && otherReasonContainer) {
        reasonSelect.addEventListener('change', function () {
            if (this.value === 'Other') {
                otherReasonContainer.style.display = '';
                if (otherReasonInput) otherReasonInput.required = true;
            } else {
                otherReasonContainer.style.display = 'none';
                if (otherReasonInput) {
                    otherReasonInput.value = '';
                    otherReasonInput.required = false;
                }
            }
        });
    }

    function initConfigureItemForm() {
        updateAddOnsAmount();

        const minusBtn = document.querySelector('.js-minus');
        const plusBtn = document.querySelector('.js-plus');
        const resultInput = document.querySelector('.js-result');
        const amountSpan = document.getElementById('configure-item-amount');

        const vendorPriceElement = document.getElementById('vendor-price');
        if (vendorPriceElement) {
            vendorPriceElement.textContent = formatCurrency(parseCurrency(vendorPriceElement.textContent));
        }
        if (amountSpan) {
            amountSpan.textContent = formatCurrency(parseCurrency(amountSpan.textContent));
        }

        document.querySelectorAll('.other-vendors-table tr:nth-child(2) td:not(:first-child)').forEach(td => {
            td.textContent = formatCurrency(parseCurrency(td.textContent));
        });

        function updateTotalAmountWithAddOns() {
            const quantity = parseInt(document.getElementById('configure-item-quantity').value) || 1;
            const unitPrice = parseCurrency(document.getElementById('vendor-price').textContent);
            const baseAmount = unitPrice * quantity;
            let addOnsTotal = 0;
            document.querySelectorAll('#add-ons-table-body tr').forEach(row => {
                const checkbox = row.querySelector('.add-on-checkbox');
                if (checkbox && checkbox.checked) {
                    const addOnUnitPrice = parseCurrency(row.cells[6].textContent);
                    addOnsTotal += addOnUnitPrice * quantity;
                }
            });
            document.getElementById('configure-item-amount').textContent = formatCurrency(baseAmount + addOnsTotal);
        }

        window.updateTotalAmountWithAddOns = updateTotalAmountWithAddOns;

        const originalUpdateAddOnsAmount = window.updateAddOnsAmount;
        window.updateAddOnsAmount = function () {
            if (typeof originalUpdateAddOnsAmount === 'function') {
                originalUpdateAddOnsAmount();
            }
            updateTotalAmountWithAddOns();
        };

        if (minusBtn && plusBtn && resultInput) {
            const newMinusBtn = minusBtn.cloneNode(true);
            const newPlusBtn = plusBtn.cloneNode(true);
            minusBtn.parentNode.replaceChild(newMinusBtn, minusBtn);
            plusBtn.parentNode.replaceChild(newPlusBtn, plusBtn);

            let unitPrice = parseCurrency(document.getElementById('vendor-price').textContent) || 10000000;

            function updateAmount() {
                const resultInput = document.getElementById('configure-item-quantity');
                const amountSpan = document.getElementById('configure-item-amount');
                const vendorPrice = parseCurrency(document.getElementById('vendor-price').textContent);
                const quantity = parseInt(resultInput.value) || 0;
                amountSpan.textContent = formatCurrency(quantity * vendorPrice);
            }

            newMinusBtn.addEventListener('click', function () {
                let value = parseInt(resultInput.value) || 0;
                if (value > 1) {
                    resultInput.value = value - 1;
                    updateAmount();
                    updateAddOnsAmount();
                }
            });
            newPlusBtn.addEventListener('click', function () {
                let value = parseInt(resultInput.value) || 0;
                resultInput.value = value + 1;
                updateAmount();
                updateAddOnsAmount();
            });

            resultInput.addEventListener('input', function () {
                let value = parseInt(this.value) || 0;
                if (value < 1) {
                    this.value = 1;
                }
                updateAmount();
                updateAddOnsAmount();
            });
        }

        document.querySelectorAll('#add-ons-table-body .add-on-checkbox').forEach(cb => {
            cb.addEventListener('change', function () {
                updateTotalAmountWithAddOns();
            });
        });

        const configureQtyInput = document.getElementById('configure-item-quantity');
        if (configureQtyInput) {
            configureQtyInput.addEventListener('input', updateAddOnsAmount);

            configureQtyInput.addEventListener('change', function () {
                updateAddOnsAmount();
                updateTotalAmountWithAddOns();
            });
        }

        function updateStockHeader() {
            const stockHeader = document.getElementById('stock-header');
            const stockTotalItem = document.getElementById('stock-total-item');
            const totalItems = parseInt(stockTotalItem.textContent) || 0;

            if (totalItems > 0) {
                stockHeader.style.backgroundColor = '#02b013';
                stockHeader.classList.remove('out-of-stock');
            } else {
                stockHeader.style.backgroundColor = '#fe0000';
                stockHeader.classList.add('out-of-stock');
            }
        }

        updateStockHeader();

        const otherVendorBtn = document.getElementById('other-vendor-btn');
        const otherVendorsTable = document.querySelector('.other-vendors-table');
        const requestToPurchasingForm = document.querySelector('.request-to-purchasing-form');
        const requestToPurchasingBtn = document.getElementById('request-to-purchasing-btn');

        if (otherVendorsTable) otherVendorsTable.style.display = 'none';
        if (requestToPurchasingForm) requestToPurchasingForm.style.display = 'none';

        if (otherVendorBtn && otherVendorsTable) {
            const newOtherVendorBtn = otherVendorBtn.cloneNode(true);
            otherVendorBtn.parentNode.replaceChild(newOtherVendorBtn, otherVendorBtn);
            newOtherVendorBtn.addEventListener('click', function () {
                otherVendorsTable.style.display = otherVendorsTable.style.display === 'none' ? 'block' : 'none';
                if (requestToPurchasingForm) {
                    requestToPurchasingForm.style.display = 'none';
                }
            });
        }

        if (requestToPurchasingBtn && requestToPurchasingForm) {
            const newRequestToPurchasingBtn = requestToPurchasingBtn.cloneNode(true);
            requestToPurchasingBtn.parentNode.replaceChild(newRequestToPurchasingBtn, requestToPurchasingBtn);
            newRequestToPurchasingBtn.addEventListener('click', function () {
                requestToPurchasingForm.style.display = requestToPurchasingForm.style.display === 'none' ? 'block' : 'none';
                if (otherVendorsTable) {
                    otherVendorsTable.style.display = 'none';
                }
            });
        }

        const chooseButtons = document.querySelectorAll('.btn-choose');
        chooseButtons.forEach(button => {
            button.addEventListener('click', function () {
                const index = parseInt(this.getAttribute('data-index'));
                const vendor = vendorData[index];

                if (vendor) {
                    document.getElementById('vendor-name').textContent = vendor.name;
                    document.getElementById('vendor-location').textContent = vendor.location;
                    document.getElementById('vendor-price').textContent = formatCurrency(vendor.price);
                    document.getElementById('vendor-validity').textContent = vendor.validityDate;
                    document.getElementById('vendor-leadtime').textContent = vendor.leadtime;

                    const resultInput = document.getElementById('configure-item-quantity');
                    const amountSpan = document.getElementById('configure-item-amount');
                    const quantity = parseInt(resultInput.value) || 0;
                    amountSpan.textContent = formatCurrency(quantity * vendor.price);

                    updateAddOnsAmount();
                }
                if (otherVendorsTable) otherVendorsTable.style.display = 'none';
            });
        });

        const closeBtn = document.getElementById('configure-item-form-close-btn');
        configureItemForm = document.querySelector('.configure-item-form-pop-up');
        if (closeBtn && configureItemForm) {
            closeBtn.addEventListener('click', function () {
                configureItemForm.classList.remove('active');
                document.body.classList.remove('pop-up-active');
                clearActiveItemListName();
            });
        }

        const cancelBtn = document.querySelector('.configure-item-form-cancel-btn');
        if (cancelBtn && configureItemForm) {
            cancelBtn.addEventListener('click', function () {
                configureItemForm.classList.remove('active');
                document.body.classList.remove('pop-up-active');
                clearActiveItemListName();
            });
        }

        const confirmBtn = document.querySelector('.configure-item-form-confirm-btn');
        if (confirmBtn) {
            const newConfirmBtn = confirmBtn.cloneNode(true);
            confirmBtn.parentNode.replaceChild(newConfirmBtn, confirmBtn);

            newConfirmBtn.addEventListener('click', function () {
                const configureItemForm = document.querySelector('.configure-item-form-pop-up');
                const requestToPurchasingForm = document.querySelector('.request-to-purchasing-form');

                // --- DEKLARASI VARIABEL DIPINDAHKAN KE ATAS SINI ---
                // Ambil data dari pop-up sekali saja di sini agar bisa dipakai di semua kondisi.
                const itemName = document.getElementById('configure-item-name-code').textContent.split(' [')[0].trim();
                const itemDesc = document.getElementById('configure-item-description').textContent.trim();
                const quantity = document.getElementById('configure-item-quantity').value;
                const price = parseCurrency(document.getElementById('vendor-price').textContent);
                // --- AKHIR BAGIAN DEKLARASI ---

                const isRequestToPurchasing = requestToPurchasingForm && requestToPurchasingForm.style.display !== 'none';

                if (isRequestToPurchasing) {
                    // --- LOGIKA UNTUK "REQUEST TO PURCHASING" ---
                    let reason = document.getElementById('reason-for-request').value;
                    if (reason === 'Other') {
                        reason = document.getElementById('other-reason-input').value.trim();
                    }
                    const notes = document.getElementById('request-details-notes').value.trim();

                    // Panggil fungsi untuk menambahkan baris baru ke tabel purchasing
                    addToRequestPurchasing({
                        name: itemName,
                        description: itemDesc,
                        quantity: quantity,
                        uom: 'Unit',
                        reason: reason,
                        notes: notes
                    });

                    // Hapus item dari tabel "Item List"
                    const itemListTableBody = document.getElementById('itemListTableBody');
                    if (itemListTableBody) {
                        const rows = Array.from(itemListTableBody.querySelectorAll('tr'));
                        for (const row of rows) {
                            const nameSpan = row.querySelector('.name .select-btn span');
                            if (nameSpan && nameSpan.textContent.trim() === itemName) {
                                row.remove();
                                break;
                            }
                        }
                        renumberItemListTable();
                        updateItemListTotal();
                        updateAddItemButtonState();
                    }

                    const addOnCheckboxes = document.querySelectorAll('#add-ons-table-body .add-on-checkbox:checked');

                    addOnCheckboxes.forEach(checkbox => {
                        const row = checkbox.closest('tr');
                        if (!row) return;

                        // Ambil data add-on seperti biasa
                        const addOnName = row.cells[2].textContent.trim();
                        const addOnDesc = row.cells[3].textContent.trim();
                        const addOnQty = quantity; // Tetap menggunakan kuantitas dari item utama
                        const addOnUom = row.cells[5].textContent.trim();

                        // 1. Kumpulkan semua data add-on ke dalam SATU OBJEK
                        const addOnItemData = {
                            name: addOnName,
                            description: addOnDesc,
                            quantity: addOnQty,
                            uom: addOnUom,
                            reason: reason, // 'reason' dari item utama
                            notes: notes    // 'notes' dari item utama
                        };

                        // 2. Panggil fungsi dengan SATU OBJEK tersebut
                        addToRequestPurchasing(addOnItemData);
                    });

                    renumberReqTable();
                } else {
                    const itemListTableBody = document.getElementById('itemListTableBody');
                    let targetRow = null;
                    if (itemListTableBody) {
                        const rows = Array.from(itemListTableBody.querySelectorAll('tr'));
                        for (const row of rows) {
                            const nameSpan = row.querySelector('.name .select-btn span');
                            if (nameSpan && nameSpan.textContent.trim() === itemName) {
                                targetRow = row;
                                break;
                            }
                        }
                    }

                    if (targetRow) {
                        targetRow.querySelector('.desc input').value = itemDesc;
                        targetRow.querySelector('.qty input').value = quantity;
                        targetRow.querySelector('.price input').value = price;
                        const itemDropdown = targetRow.querySelector('.wrapp.item-dropdown');
                        if (itemDropdown) {
                            itemDropdown.classList.add('disabled-by-script');
                            itemDropdown.setAttribute('tabindex', '-1');
                        }
                        updateRowAmount(targetRow.querySelector('.qty input'));
                    } else {
                        addToItemList(itemName, itemDesc, quantity, price);
                        const rows = Array.from(itemListTableBody.querySelectorAll('tr'));
                        targetRow = rows[rows.length - 1];
                    }

                    const addOnCheckboxes = document.querySelectorAll('#add-ons-table-body .add-on-checkbox:checked');
                    let insertAfter = targetRow;
                    addOnCheckboxes.forEach(checkbox => {
                        const row = checkbox.closest('tr');
                        if (!row) return;
                        const addOnName = row.cells[2].textContent.trim();
                        const addOnDesc = row.cells[3].textContent.trim();
                        const addOnQty = row.cells[4].textContent.trim();
                        const addOnUom = row.cells[5].textContent.trim();
                        const addOnPrice = parseCurrency(row.cells[6].textContent);

                        const newRow = document.createElement('tr');
                        newRow.classList.add('addon-row');
                        const newAddonIndex = itemListTableBody.querySelectorAll('tr').length;
                        newRow.innerHTML = `
                            <td></td>
                            <td class="name">
                                <input type="hidden" name="ItemListSectionItems[${newAddonIndex}].ItemID" value="">
                                <div class="wrapp item-dropdown" style="width: 100%;">
                                    <div class="select-btn d-flex align-items-center"><span>${addOnName}</span><i class='bx bx-chevron-down'></i></div>
                                    <div class="content-search">
                                        <div class="search"><i class="bx bx-search-alt-2"></i><input type="text" placeholder="Search" /></div>
                                        <ul class="option" style="margin-bottom: 10px;"></ul>
                                    </div>
                                </div>
                            </td>
                            <td class="desc"><input type='text' class='size form-control1' name="ItemListSectionItems[${newAddonIndex}].ItemDescription" value="${addOnDesc}"></td>
                            <td class="qty"><input type='number' class='size text-center form-control1' name="ItemListSectionItems[${newAddonIndex}].Quantity" value="${addOnQty}"></td>
                            <td class="uom"><input type='text' class='size form-control1' name="ItemListSectionItems[${newAddonIndex}].UoM" value="${addOnUom}"></td>
                            <td class="price"><input type='number' class='size form-control1' name="ItemListSectionItems[${newAddonIndex}].TargetUnitPrice" value="${addOnPrice}"></td>
                            <td class="notes"><input type='text' class='size form-control1' name="ItemListSectionItems[${newAddonIndex}].Notes"></td>
                            <td class="details"><input type='text' class='size form-control1' name="ItemListSectionItems[${newAddonIndex}].Details"></td>
                            <td class="warranty"><input type='text' class='size form-control1' name="ItemListSectionItems[${newAddonIndex}].SalesWarranty"></td>
                            <td class="amount"><span class="item-price-amount"></span></td>
                            <td class="delete"><button type="button" class="btn btn-remove-row-itemlist"><i class='bx bx-trash'></i></button></td>
                        `;
                        if (insertAfter && insertAfter.nextSibling) {
                            itemListTableBody.insertBefore(newRow, insertAfter.nextSibling);
                        } else {
                            itemListTableBody.appendChild(newRow);
                        }
                        insertAfter = newRow;

                        setupItemDropdown(newRow.querySelector('.wrapp.item-dropdown'));
                        const addOnDropdown = newRow.querySelector('.wrapp.item-dropdown');
                        if (addOnDropdown) {
                            addOnDropdown.classList.add('disabled-by-script');
                            addOnDropdown.setAttribute('tabindex', '-1');
                        }
                        newRow.querySelectorAll('input').forEach(input => {
                            input.addEventListener('input', function () {
                                updateAddItemButtonState();
                            });
                        });
                        const selectBtn = newRow.querySelector('.select-btn');
                        if (selectBtn) {
                            selectBtn.addEventListener('click', function () {
                                setTimeout(updateAddItemButtonState, 100);
                            });
                        }
                        const deleteBtn = newRow.querySelector('.btn-remove-row-itemlist');
                        deleteBtn.addEventListener('click', function () {
                            newRow.remove();
                            renumberItemListTable();
                            updateItemListTotal();
                            updateAddItemButtonState();
                        });

                        updateRowAmount(newRow.querySelector('.qty input'));
                    });

                    renumberItemListTable();
                    updateItemListTotal();
                    updateAddItemButtonState();
                }

                if (configureItemForm) {
                    configureItemForm.classList.remove('active');
                }
                document.body.classList.remove('pop-up-active');
            });
        }
    }

    function setupConfigureItemPopup() {
        const itemListTableBody = document.getElementById('itemListTableBody');
        if (!itemListTableBody) return;

        itemListTableBody.addEventListener('click', function (e) {
            const target = e.target;
            const itemNameElement = target.closest('.select-btn span');

            if (itemNameElement && !itemNameElement.textContent.includes('Create "')) {
                const itemName = itemNameElement.textContent.trim();

                configureItemForm = document.querySelector('.configure-item-form-pop-up');
                if (configureItemForm) {
                    resetConfigureItemForm();
                    setDefaultVendor();

                    const itemNameCodeElement = document.getElementById('configure-item-name-code');
                    if (itemNameCodeElement) {
                        itemNameCodeElement.textContent = `${itemName} [HWY00001]`;
                    }

                    const quantityInput = document.getElementById('configure-item-quantity');
                    if (quantityInput) {
                        quantityInput.value = 1;
                    }

                    const amountElement = document.getElementById('configure-item-amount');
                    const vendorPriceElement = document.getElementById('vendor-price');
                    if (amountElement && vendorPriceElement) {
                        amountElement.textContent = formatCurrency(parseCurrency(vendorPriceElement.textContent));

                    }

                    configureItemForm.classList.add('active');
                    document.body.classList.add('pop-up-active');

                    initConfigureItemForm();
                }
            }
        });
    }

    setupConfigureItemPopup();

    const existingItemDropdowns = document.querySelectorAll('.wrapp.item-dropdown');
    existingItemDropdowns.forEach(dropdown => {
        const selectBtn = dropdown.querySelector('.select-btn');
        if (selectBtn) {
            selectBtn.addEventListener('click', function (e) {
                setTimeout(() => {
                    const options = dropdown.querySelectorAll('.option li:not(.create-option)');
                    options.forEach(option => {
                        option.addEventListener('click', function () {
                            const itemName = this.textContent.trim();
                            if (itemName && !itemName.includes('Create "')) {
                                configureItemForm = document.querySelector('.configure-item-form-pop-up');
                                if (configureItemForm) {
                                    const itemNameCodeElement = document.getElementById('configure-item-name-code');
                                    if (itemNameCodeElement) {
                                        itemNameCodeElement.textContent = `${itemName} [HWY00001]`;
                                    }

                                    const quantityInput = document.getElementById('configure-item-quantity');
                                    if (quantityInput) {
                                        quantityInput.value = 1;
                                    }

                                    const amountElement = document.getElementById('configure-item-amount');
                                    const vendorPriceElement = document.getElementById('vendor-price');
                                    if (amountElement && vendorPriceElement) {
                                        amountElement.textContent = formatCurrency(parseCurrency(vendorPriceElement.textContent));

                                    }

                                    configureItemForm.classList.add('active');
                                    document.body.classList.add('pop-up-active');

                                    initConfigureItemForm();
                                }
                            }
                        });
                    });
                }, 100);
            });
        }
    });

    document.querySelectorAll('.survey-category-dropdown').forEach(setupMultiSelectDropdown);
    document.querySelectorAll('.survey-pic-dropdown').forEach(setupMultiSelectDropdown);
    document.querySelectorAll('.meeting-pic-dropdown').forEach(setupMultiSelectDropdown);

/*    const surveyTableBody = document.getElementById("surveyTableBody");
    const addRowBtnSurvey = document.getElementById("addRowBtnSurvey");

    if (addRowBtnSurvey) {
        addRowBtnSurvey.addEventListener("click", function () {
            const tbody = document.getElementById("surveyTableBody");
            const rows = tbody.querySelectorAll("tr");
            const newIndex = tbody.querySelectorAll("tr").length;
            const lastRow = rows[rows.length - 1];

            *//*const categoryChecked = lastRow.querySelectorAll('.survey-category-dropdown .survey-list-checkboxes:checked').length > 0;
            const surveyName = lastRow.querySelector('.survey-name input')?.value.trim();
            const picChecked = lastRow.querySelectorAll('.survey-pic-dropdown .survey-list-checkboxes:checked').length > 0;
            const customerPic = lastRow.querySelector('.survey-customer-pic input')?.value.trim();
            const reqDateTime = lastRow.querySelector('.survey-req-date-time input')?.value.trim();
            const detailLocation = lastRow.querySelector('.survey-detail-location input')?.value.trim();
            const notes = lastRow.querySelector('.survey-notes input')?.value.trim();

            if (
                !categoryChecked &&
                !surveyName &&
                !picChecked &&
                !customerPic &&
                !reqDateTime &&
                !detailLocation &&
                !notes
            ) {
                return;
            }*//*

            // --- MEMBUAT OPSI UNTUK DROPDOWN CATEGORY ---
            let categoryOptionsHtml = '';
            if (typeof surveyCategoriesFromServer !== 'undefined') {
                surveyCategoriesFromServer.forEach(cat => {
                    categoryOptionsHtml += `
                    <li>
                        <input type="checkbox" class="survey-list-checkboxes me-2" name="SurveySectionItems[${newIndex}].SurveyCategoryIDs" value="${cat.value}">
                        <span>${cat.text}</span>
                    </li>`;
                });
            }

            // --- MEMBUAT OPSI UNTUK DROPDOWN PIC ---
            let picOptionsHtml = '';
            // Gunakan 'surveyUsersFromServer' yang baru, bukan 'usersFromServer'
            if (typeof surveyUsersFromServer !== 'undefined') {
                surveyUsersFromServer.forEach(user => {
                    picOptionsHtml += `
                    <li>
                        <input type="checkbox" class="survey-list-checkboxes me-2" name="SurveySectionItems[${newIndex}].TechnicalUserIDs" value="${user.value}">
                        <span>${user.text}</span>
                    </li>`;
                });
            }

            const rowCount = surveyTableBody.querySelectorAll("tr").length;
            const newRow = document.createElement("tr");
            newRow.innerHTML = `
            <td class="text-center" style="font-weight: 500;">${newIndex + 1}</td>
            <td class="survey-code">None</td>
            <td class="survey-category">
                <div class="wrapp survey-category-dropdown">
                    <div class="select-btn py-0">
                        <input type="text" class="form-control ps-0" readonly style="background: transparent; border: none; box-shadow: none;" placeholder="Pilih Kategori"/>
                        <i class='bx bx-chevron-down'></i>
                    </div>
                    <div class="content-search"><ul class="option" style="margin-bottom: 10px; padding-left: 0rem;">${categoryOptionsHtml}</ul></div>
                </div>
            </td>
            <td class="survey-name"><input type="text" class="size form-control1" name="SurveySectionItems[${newIndex}].SurveyName"></td>
            <td class="survey-pic">
                <div class="wrapp survey-pic-dropdown">
                    <div class="select-btn py-0">
                        <input type="text" class="form-control ps-0" readonly style="background: transparent; border: none; box-shadow: none;" placeholder="Pilih PIC"/>
                        <i class='bx bx-chevron-down'></i>
                    </div>
                    <div class="content-search"><ul class="option" style="margin-bottom: 10px; padding-left: 0rem;">${picOptionsHtml}</ul></div>
                </div>
            </td>
            <td class="survey-customer-pic"><input type="text" class="size form-control1" name="SurveySectionItems[${newIndex}].CustomerPICName"></td>
            <td class="survey-req-date-time">
                <input type="hidden" asp-for="SurveySectionItems[${newIndex}].RequestedDateTime" />
                <div class="d-flex flex-column gap-1">
                    <input type="date" class="form-control form-control-sm survey-date" 
                           value="@Model.SurveySectionItems[${newIndex}].RequestedDateTime.ToString("yyyy-MM-dd")">
                    <div class="d-flex gap-1 align-items-center">
                        <input type="time" class="form-control form-control-sm survey-time-start" 
                               value="@Model.SurveySectionItems[${newIndex}].RequestedDateTime.ToString("HH:mm")">
                        <span>-</span>
                        <input type="time" class="form-control form-control-sm survey-time-end">
                    </div>
                </div>
            </td>
            <td class="survey-detail-location"><input type="text" class="size form-control1" name="SurveySectionItems[${newIndex}].LocationDetails"></td>
            <td class="survey-notes"><input type="text" class="size form-control1" name="SurveySectionItems[${newIndex}].SalesNotesInternal"></td>
            <td class="survey-status"><div class="d-flex justify-content-center align-items-center flex-column gap-1"><span class="rounded-pill status">Open</span></div></td>
            <td class="survey-actions">
                <div class="d-flex justify-content-center">
                    <button type="button" class="btn"><i class='bx bx-file'></i></button>
                    <button type="button" class="btn btn-remove-row-survey"><i class='bx bx-trash'></i></button>
                </div>
            </td>
        `;
            tbody.appendChild(newRow);
            renumberTableRows("surveyTableBody");

            setupMultiSelectDropdown(newRow.querySelector('.survey-category-dropdown'));
            setupMultiSelectDropdown(newRow.querySelector('.survey-pic-dropdown'));

            const newCategoryDropdown = newRow.querySelector('.survey-category-dropdown');
            if (newCategoryDropdown) setupMultiSelectDropdown(newCategoryDropdown);

            const newPicDropdown = newRow.querySelector('.survey-pic-dropdown');
            if (newPicDropdown) setupMultiSelectDropdown(newPicDropdown);
        });
    }

    surveyTableBody.addEventListener("click", function (e) {
        if (e.target.closest(".btn-remove-row-survey")) {
            const row = e.target.closest("tr");
            if (row) {
                row.remove();
                renumberTableRows("surveyTableBody");
            }
        }
    });

    document.getElementById('surveyTableBody').addEventListener('click', function (e) {
        const dropdown = e.target.closest('.wrapp#survey-category-dropdown');
        if (dropdown) {
            closeAllDropdowns();
            dropdown.classList.add('active');
        }
    });

    document.getElementById('surveyTableBody').addEventListener('click', function (e) {
        if (e.target.matches('.wrapp#survey-category-dropdown .option li')) {
            const li = e.target;
            const dropdown = li.closest('.wrapp#survey-category-dropdown');
            const span = dropdown.querySelector('.select-btn span');
            if (span) span.textContent = li.textContent;
            dropdown.classList.remove('active');
        }
    });

    document.addEventListener('click', function (e) {
        if (!e.target.closest('.wrapp#survey-category-dropdown')) {
            document.querySelectorAll('.wrapp#survey-category-dropdown').forEach(d => d.classList.remove('active'));
        }
    });

    document.getElementById('surveyTableBody').addEventListener('click', function (e) {
        const dropdown = e.target.closest('.wrapp#survey-pic-dropdown');
        if (dropdown) {
            document.querySelectorAll('.wrapp#survey-pic-dropdown').forEach(d => {
                if (d !== dropdown) d.classList.remove('active');
            });
            dropdown.classList.toggle('active');
        }
    });

    document.getElementById('surveyTableBody').addEventListener('click', function (e) {
        if (e.target.matches('.wrapp#survey-pic-dropdown .option li')) {
            const li = e.target;
            const dropdown = li.closest('.wrapp#survey-pic-dropdown');
            const span = dropdown.querySelector('.select-btn span');
            if (span) span.textContent = li.textContent.trim();
            dropdown.classList.remove('active');
        }
    });

    document.addEventListener('click', function (e) {
        if (!e.target.closest('.wrapp#survey-pic-dropdown')) {
            document.querySelectorAll('.wrapp#survey-pic-dropdown').forEach(d => d.classList.remove('active'));
        }
    });

    document.getElementById('surveyTableBody').addEventListener('input', function (e) {
        const row = e.target.closest('tr');
        if (!row) return;
        const date = row.querySelector('.survey-date')?.value;
        const timeStart = row.querySelector('.survey-time-start')?.value;
        const timeEnd = row.querySelector('.survey-time-end')?.value;
        const display = row.querySelector('.survey-date-display');

        if (timeStart && timeEnd) {
            if (timeEnd < timeStart) {
                row.querySelector('.survey-time-end').value = '';
                row.querySelector('.survey-time-end').classList.add('is-invalid');
                if (!row.querySelector('.survey-time-end').nextElementSibling || !row.querySelector('.survey-time-end').nextElementSibling.classList.contains('invalid-feedback')) {
                    const feedback = document.createElement('div');
                    feedback.className = 'invalid-feedback';
                    feedback.textContent = 'End time must be after start time';
                    row.querySelector('.survey-time-end').after(feedback);
                }
            } else {
                row.querySelector('.survey-time-end').classList.remove('is-invalid');
                const feedback = row.querySelector('.survey-time-end').nextElementSibling;
                if (feedback && feedback.classList.contains('invalid-feedback')) {
                    feedback.remove();
                }
            }
        } else {
            row.querySelector('.survey-time-end')?.classList.remove('is-invalid');
            const feedback = row.querySelector('.survey-time-end')?.nextElementSibling;
            if (feedback && feedback.classList.contains('invalid-feedback')) {
                feedback.remove();
            }
        }

        if (display) {
            if (timeStart && timeEnd && timeEnd >= timeStart) {
                display.value = formatSurveyDateTime(date, timeStart, timeEnd);
            } else {
                display.value = '';
            }
        }
    });*/

    // Di dalam file wwwroot/js/site.js, di dalam DOMContentLoaded

    // Hapus fungsi setupMultiSelectDropdown yang lama dan semua event listener
    // yang berhubungan dengan surveyTableBody. Ganti dengan kode di bawah ini.

    // =======================================================================
    // BLOK KODE BARU UNTUK MENGELOLA SEMUA INTERAKSI TABEL SURVEY
    // =======================================================================

    const surveyTableBody = document.getElementById("surveyTableBody");

    // Fungsi ini HANYA untuk memperbarui teks di display dropdown
    function updateMultiSelectDisplay(wrapp) {
        const displayInput = wrapp.querySelector('.select-btn input[type="text"]');
        const checkboxes = wrapp.querySelectorAll('.option .survey-list-checkboxes:checked');

        const selectedTexts = Array.from(checkboxes).map(cb => {
            return cb.nextElementSibling?.textContent.trim();
        });

        if (displayInput) {
            displayInput.value = selectedTexts.join(', ');
        }
    }

    // Fungsi ini HANYA untuk menangani klik buka/tutup dropdown
    function handleDropdownToggle(e) {
        const selectBtn = e.target.closest('.select-btn');
        if (!selectBtn) return;

        const wrapp = selectBtn.closest('.wrapp');
        if (!wrapp) return;

        e.stopPropagation();
        const isActive = wrapp.classList.contains('active');
        closeAllDropdowns(); // Gunakan fungsi global Anda
        if (!isActive) {
            wrapp.classList.add('active');
        }
    }

    // SATU EVENT LISTENER UTAMA untuk seluruh tabel survey
    if (surveyTableBody) {
        surveyTableBody.addEventListener('click', function (e) {
            // Menangani buka/tutup dropdown
            handleDropdownToggle(e);

            // Menangani klik pada checkbox untuk update display
            if (e.target.classList.contains('survey-list-checkboxes')) {
                const wrapp = e.target.closest('.wrapp');
                updateMultiSelectDisplay(wrapp);
            }

            // Menangani tombol hapus baris
            if (e.target.closest('.btn-remove-row-survey')) {
                e.target.closest('tr').remove();
                renumberTableRows('surveyTableBody');
            }
        });

        // Menangani perubahan pada input tanggal & waktu
        surveyTableBody.addEventListener('change', function (e) {
            if (e.target.matches('.survey-date, .survey-time-start, .survey-time-end')) {
                const row = e.target.closest('tr');
                if (!row) return;

                // Ambil semua elemen input yang relevan dari baris tersebut
                const dateInput = row.querySelector('.survey-date');
                const startTimeInput = row.querySelector('.survey-time-start');
                const endTimeInput = row.querySelector('.survey-time-end');
                const displayInput = row.querySelector('.survey-date-display');

                // Dapatkan kedua input tersembunyi berdasarkan atribut 'name' mereka
                const hiddenStartInput = row.querySelector('input[name*="RequestStartTime"]');
                const hiddenEndInput = row.querySelector('input[name*="RequestEndTime"]');

                let isValid = true;
                // 1. Selalu cari dan hapus pesan error yang mungkin sudah ada di baris ini
                const existingError = row.querySelector('.invalid-feedback');
                if (existingError) {
                    existingError.remove();
                }
                endTimeInput.classList.remove('is-invalid');

                // 2. Lakukan perbandingan jika kedua input waktu sudah diisi
                if (startTimeInput.value && endTimeInput.value) {
                    if (endTimeInput.value < startTimeInput.value) {
                        // Beri tanda visual pada input yang salah
                        endTimeInput.classList.add('is-invalid');

                        // Buat elemen div untuk pesan error
                        const errorDiv = document.createElement('div');
                        errorDiv.className = 'invalid-feedback d-block';
                        errorDiv.innerText = '*Waktu selesai tidak boleh lebih awal dari waktu mulai.';

                        // 3. Tempatkan pesan error TEPAT DI BAWAH input display tanggal
                        if (displayInput) {
                            displayInput.after(errorDiv);
                        }

                        isValid = false; // Tandai sebagai tidak valid
                    }
                }

                // Hanya update nilai jika valid
                if (isValid) {
                    // Update hidden input untuk Waktu Mulai
                    if (dateInput?.value && startTimeInput?.value && hiddenStartInput) {
                        hiddenStartInput.value = `${dateInput.value}T${startTimeInput.value}`;
                    }

                    // Update hidden input untuk Waktu Selesai
                    if (dateInput?.value && endTimeInput?.value && hiddenEndInput) {
                        hiddenEndInput.value = `${dateInput.value}T${endTimeInput.value}`;
                    }

                    // Update teks display jika semua input valid dan terisi
                    if (displayInput && dateInput.value && startTimeInput.value && endTimeInput.value) {
                        displayInput.value = formatSurveyDateTime(dateInput.value, startTimeInput.value, endTimeInput.value);
                    } else if (displayInput) {
                        displayInput.value = '';
                    }
                } else {
                    // Jika tidak valid, kosongkan nilai yang salah dan display
                    if (displayInput) displayInput.value = '';
                    if (hiddenEndInput) hiddenEndInput.value = '';
                }
            }
        });
    }


    // Logika untuk tombol "Add Survey"
    const addRowBtnSurvey = document.getElementById("addRowBtnSurvey");
    if (addRowBtnSurvey) {
        addRowBtnSurvey.addEventListener("click", function () {
            const tbody = document.getElementById("surveyTableBody");
            const newIndex = tbody.querySelectorAll("tr").length;
            const newRow = document.createElement("tr");

            let categoryOptionsHtml = (surveyCategoriesFromServer || []).map(cat => `
            <li>
                <label class="posisi-sejajar">
                    <input type="checkbox" class="survey-list-checkboxes me-2" name="SurveySectionItems[${newIndex}].SurveyCategoryIDs" value="${cat.value}">
                    <span>${cat.text}</span>
                </label>
            </li>`).join('');

            // --- REVISI DI SINI: Tambahkan <label> ---
            let picOptionsHtml = (surveyUsersFromServer || []).map(user => `
            <li>
                <label class="posisi-sejajar">
                    <input type="checkbox" class="survey-list-checkboxes me-2" name="SurveySectionItems[${newIndex}].TechnicalUserIDs" value="${user.value}">
                    <span>${user.text}</span>
                </label>
            </li>`).join('');

            newRow.innerHTML = `
            <td class="text-center" style="font-weight: 500;">${newIndex + 1}</td>
            <td class="survey-code">None</td>
            <td class="survey-category">
                <div class="wrapp survey-category-dropdown"><div class="select-btn py-0"><input type="text" class="form-control ps-0" readonly style="background: transparent; border: none; box-shadow: none;" placeholder="Pilih Kategori"/><i class='bx bx-chevron-down'></i></div><div class="content-search"><ul class="option" style="margin-bottom: 10px; padding-left: 0rem;">${categoryOptionsHtml}</ul></div></div>
            </td>
            <td class="survey-name"><input type="text" class="size form-control1" name="SurveySectionItems[${newIndex}].SurveyName"></td>
            <td class="survey-pic">
                <div class="wrapp survey-pic-dropdown"><div class="select-btn py-0"><input type="text" class="form-control ps-0" readonly style="background: transparent; border: none; box-shadow: none;" placeholder="Pilih PIC"/><i class='bx bx-chevron-down'></i></div><div class="content-search"><ul class="option" style="margin-bottom: 10px; padding-left: 0rem;">${picOptionsHtml}</ul></div></div>
            </td>
            <td class="survey-customer-pic"><input type="text" class="size form-control1" name="SurveySectionItems[${newIndex}].CustomerPICName"></td>
            <td class="survey-req-date-time">
                <input type="hidden" name="SurveySectionItems[${newIndex}].RequestStartTime" />
                <input type="hidden" name="SurveySectionItems[${newIndex}].RequestEndTime" />
                <div class="d-flex flex-column gap-1">
                    <input type="date" class="form-control form-control-sm survey-date">
                    <div class="d-flex gap-1 align-items-center">
                        <input type="time" class="form-control form-control-sm survey-time-start">
                        <span>-</span>
                        <input type="time" class="form-control form-control-sm survey-time-end">
                    </div>
                        <input type="text" class="form-control form-control-sm survey-date-display" readonly style="background: #f8f9fa; border: none; font-weight: 500;">
                </div>
            </td>
            <td class="survey-detail-location"><input type="text" class="size form-control1" name="SurveySectionItems[${newIndex}].LocationDetails"></td>
            <td class="survey-notes"><input type="text" class="size form-control1" name="SurveySectionItems[${newIndex}].SalesNotesInternal"></td>
            <td class="survey-status"><div class="d-flex justify-content-center align-items-center flex-column gap-1"><span id="open" class="rounded-pill status">Open</span></div></td>
            <td class="survey-actions"><div class="d-flex justify-content-center"><button type="button" class="btn"><i class="bx bx-file"></i></button><button type="button" class="btn btn-remove-row-survey"><i class="bx bx-trash"></i></button></div></td>
        `;

            tbody.appendChild(newRow);
        });
    }

    // Inisialisasi untuk baris yang sudah ada saat halaman dimuat
    document.querySelectorAll('.survey-category-dropdown, .survey-pic-dropdown').forEach(wrapp => {
        updateMultiSelectDisplay(wrapp);
    });
    // =======================================================================


    function initializeMeetingTable() {
        const meetingTableBody = document.getElementById("meetingTableBody");
        if (!meetingTableBody) return;

        // Fungsi untuk memperbarui display awal
        const updateAllRowsDisplay = () => {
            meetingTableBody.querySelectorAll('tr').forEach(row => {
                const dateInput = row.querySelector('.meeting-date');
                const startTimeInput = row.querySelector('.meeting-time-start');
                const endTimeInput = row.querySelector('.meeting-time-end');
                const displayInput = row.querySelector('.meeting-date-display');
                if (displayInput && dateInput.value && startTimeInput.value && endTimeInput.value) {
                    displayInput.value = formatMeetingDateTime(dateInput.value, startTimeInput.value, endTimeInput.value);
                }
            });
        };

        updateAllRowsDisplay();
        meetingTableBody.querySelectorAll('.meeting-pic-dropdown').forEach(updateMultiSelectDisplay);

        // Event listener utama untuk semua klik
        meetingTableBody.addEventListener('click', function (e) { /* ... (kode ini sama seperti sebelumnya) ... */ });

        // Event listener untuk perubahan input tanggal & waktu dengan validasi
        meetingTableBody.addEventListener('change', function (e) {
            if (e.target.matches('.meeting-date, .meeting-time-start, .meeting-time-end')) {
                const row = e.target.closest('tr');
                if (!row) return;

                const dateTimeCell = e.target.closest('.meeting-req-date-time');
                const dateInput = row.querySelector('.meeting-date');
                const startTimeInput = row.querySelector('.meeting-time-start');
                const endTimeInput = row.querySelector('.meeting-time-end');
                const displayInput = row.querySelector('.meeting-date-display');
                const hiddenStartInput = row.querySelector('input[name*="MeetingStartTime"]');
                const hiddenEndInput = row.querySelector('input[name*="MeetingEndTime"]');
                let isValid = true;

                const existingError = dateTimeCell.querySelector('.invalid-feedback');
                if (existingError) { existingError.remove(); }
                endTimeInput.classList.remove('is-invalid');

                if (startTimeInput.value && endTimeInput.value) {
                    if (endTimeInput.value < startTimeInput.value) {
                        endTimeInput.classList.add('is-invalid');
                        const errorDiv = document.createElement('div');
                        errorDiv.className = 'invalid-feedback d-block';
                        errorDiv.innerText = 'Waktu selesai tidak boleh lebih awal dari waktu mulai.';
                        if (displayInput) { displayInput.after(errorDiv); }
                        isValid = false;
                    }
                }

                if (isValid) {
                    if (dateInput?.value && startTimeInput?.value) { hiddenStartInput.value = `${dateInput.value}T${startTimeInput.value}`; }
                    if (dateInput?.value && endTimeInput?.value) { hiddenEndInput.value = `${dateInput.value}T${endTimeInput.value}`; }
                    if (displayInput && dateInput.value && startTimeInput.value && endTimeInput.value) {
                        displayInput.value = formatMeetingDateTime(dateInput.value, startTimeInput.value, endTimeInput.value);
                    } else if (displayInput) {
                        displayInput.value = '';
                    }
                } else {
                    if (displayInput) displayInput.value = '';
                    if (hiddenEndInput) hiddenEndInput.value = '';
                }
            }
        });

        // Logika untuk tombol "Add Meeting"
        const addMeetingBtn = document.getElementById("addMeetingBtn");
        if (addMeetingBtn) {
            addMeetingBtn.addEventListener("click", function () {
                const newIndex = meetingTableBody.querySelectorAll("tr").length;
                const newRow = document.createElement("tr");

                let picOptionsHtml = (usersFromServer || []).map(user => `<li><label><input type="checkbox" class="survey-list-checkboxes me-2" name="MeetingSectionItems[${newIndex}].AssignedPICs" value="${user.value}"><span>${user.text}</span></label></li>`).join('');

                newRow.innerHTML = `
                <td class="text-center" style="font-weight: 500;">${newIndex + 1}</td>
                <td class="meeting-code">None</td>
                <td class="meeting-name"><input type="text" class="size form-control1" name="MeetingSectionItems[${newIndex}].MeetingName"></td>
                <td class="meeting-pic"><div class="wrapp meeting-pic-dropdown"><div class="select-btn py-0"><input type="text" class="form-control ps-0" readonly style="background: transparent; border: none; box-shadow: none;" placeholder="Pilih PIC"/><i class="bx bx-chevron-down"></i></div><div class="content-search"><ul class="option" style="margin-bottom: 10px; padding-left: 0rem;">${picOptionsHtml}</ul></div></div></td>
                <td class="meeting-req-date-time">
                    <input type="hidden" name="MeetingSectionItems[${newIndex}].MeetingStartTime" />
                    <input type="hidden" name="MeetingSectionItems[${newIndex}].MeetingEndTime" />
                    <div class="d-flex flex-column gap-1">
                        <input type="date" class="form-control form-control-sm meeting-date">
                        <div class="d-flex gap-1 align-items-center">
                            <input type="time" class="form-control form-control-sm meeting-time-start">
                            <span>-</span>
                            <input type="time" class="form-control form-control-sm meeting-time-end">
                        </div>
                        <input type="text" class="form-control form-control-sm meeting-date-display" readonly style="background: #f8f9fa; border: none; font-weight: 500;">
                    </div>
                </td>
                <td class="meeting-detail-location"><input type="text" class="size form-control1" name="MeetingSectionItems[${newIndex}].LocationDetails"></td>
                <td class="meeting-notes"><input type="text" class="size form-control1" name="MeetingSectionItems[${newIndex}].NotesInternal"></td>
                <td class="meeting-status"><div class="d-flex justify-content-center align-items-center flex-column gap-1"><span class="rounded-pill status">Open</span></div></td>
                <td class="meeting-actions"><div class="d-flex justify-content-center"><button type="button" class="btn"><i class='bx bx-file'></i></button><button type="button" class="btn btn-remove-row-meeting"><i class='bx bx-trash'></i></button></div></td>
            `;
                meetingTableBody.appendChild(newRow);
            });
        }
    }

    // Panggil fungsi inisialisasi utama untuk tabel meeting
    initializeMeetingTable();


    const buttonGroup = document.getElementById('buttonGroup');
    const saveBtn = document.getElementById('save-rfq-btn');
    const discardBtn = document.getElementById('discard-btn');

    function renderSaveDiscard() {
        buttonGroup.innerHTML = `
            <button type="submit" id="save-rfq-btn" class="btn border-0 shadow-none btn-text" style="font-size: 20px; font-weight: 500;">Save</button>
            <button type="button" class="btn border-0 shadow-none btn-text" style="font-size: 20px; font-weight: 500;" id="discard-btn">
                <a class="text-decoration-none text-black" href="/RFQ/Index">Discard</a>
            </button>
        `;
        document.getElementById('save-rfq-btn').addEventListener('click', onSaveClick);
        document.getElementById('discard-btn').addEventListener('click', () => window.location.href = '/RFQ/Index');
    }

    function renderSendEditDiscard() {
        buttonGroup.innerHTML = `
            <button type="button" id="send-btn" class="btn border-0 shadow-none btn-text" style="font-size: 20px; font-weight: 500;">Send</button>
            <button type="button" id="edit-btn" class="btn border-0 shadow-none btn-text" style="font-size: 20px; font-weight: 500;">Edit</button>
            <button type="button" id="discard-btn" class="btn border-0 shadow-none btn-text" style="font-size: 20px; font-weight: 500;">
                <a class="text-decoration-none text-black" href="/RFQ/Index">Discard</a>
            </button>
        `;
        document.getElementById('edit-btn').addEventListener('click', onEditClick);
        document.getElementById('discard-btn').addEventListener('click', () => window.location.href = '/RFQ/Index');
    }

    function isNotesRowEmpty(row) {
        const name = row.querySelector('td.name input')?.value.trim();
        const desc = row.querySelector('td.desc input')?.value.trim();
        const qty = row.querySelector('td.qty input')?.value.trim();
        const uom = row.querySelector('td.uom input')?.value.trim();
        const budget = row.querySelector('td.budget input')?.value.trim();
        const leadtime = row.querySelector('td.leadtime input')?.value.trim();
        return !name && !desc && !qty && !uom && !budget && !leadtime;
    }

    function isItemListRowEmpty(row) {
        const name = row.querySelector('.name .select-btn span')?.textContent.trim();
        const desc = row.querySelector('td.desc input')?.value.trim();
        const qty = row.querySelector('td.qty input')?.value.trim();
        const uom = row.querySelector('td.uom input')?.value.trim();
        const price = row.querySelector('td.price input')?.value.trim();
        const notes = row.querySelector('td.notes input')?.value.trim();
        const details = row.querySelector('td.details input')?.value.trim();
        const warranty = row.querySelector('td.warranty input')?.value.trim();
        return !name && !desc && !qty && !uom && !price && !notes && !details && !warranty;
    }

    function isSurveyListRowEmpty(row) {
        // Ambil semua input yang bisa diisi pengguna (teks, tanggal, waktu, angka)
        const inputs = row.querySelectorAll('input[type="text"], input[type="date"], input[type="time"], input[type="number"]');

        // Cek apakah semua input tersebut benar-benar kosong
        const allInputsEmpty = Array.from(inputs).every(input => !input.value.trim());

        // Cek apakah ada satu saja checkbox yang tercentang
        const anyCheckboxChecked = row.querySelector('input[type="checkbox"]:checked');

        // Baris dianggap kosong HANYA JIKA semua input teks/tanggal/dll kosong DAN tidak ada satupun checkbox yang tercentang.
        return allInputsEmpty && !anyCheckboxChecked;
    }

    function onSaveClick(e) {
        // 1. Hentikan pengiriman otomatis untuk memberi waktu pada script
        e.preventDefault();

        // 2. Jalankan pembersihan untuk setiap tabel
        const notesTableBody = document.getElementById('itemTableBody');
        if (notesTableBody) {
            Array.from(notesTableBody.querySelectorAll('tr')).forEach(row => {
                if (isNotesRowEmpty(row)) row.remove();
            });
        }

        const itemListTableBody = document.getElementById('itemListTableBody');
        if (itemListTableBody) {
            Array.from(itemListTableBody.querySelectorAll('tr')).forEach(row => {
                if (isItemListRowEmpty(row)) row.remove();
            });
        }

        const surveyTableBody = document.getElementById('surveyTableBody');
        if (surveyTableBody) {
            Array.from(surveyTableBody.querySelectorAll('tr')).forEach(row => {
                if (isSurveyListRowEmpty(row)) row.remove();
            });
        }

        const meetingTableBody = document.getElementById('meetingTableBody');
        if (meetingTableBody) {
            Array.from(meetingTableBody.querySelectorAll('tr')).forEach(row => {
                if (isMeetingRowEmpty(row)) row.remove();
            });
        }

        // Penomoran ulang dan kalkulasi setelah semua potensi penghapusan selesai
        if (notesTableBody) renumberTableRows('itemTableBody');
        if (itemListTableBody) {
            renumberItemListTable();
            updateItemListTotal();
        }
        if (surveyTableBody) renumberTableRows('surveyTableBody');
        if (meetingTableBody) renumberTableRows('meetingTableBody');


        // 3. Submit form SETELAH jeda singkat untuk memastikan DOM sudah terupdate
        const form = document.getElementById('create-rfq-form');
        if (form) {
            setTimeout(function () {
                form.submit();
            }, 1000); // Jeda 100 milidetik
        }
    }


    function onEditClick() {
        enableAllFormFields();
        renderSaveDiscard();
    }

    
    if (buttonGroup) {
        const saveBtn = buttonGroup.querySelector('#save-rfq-btn');
        const discardBtn = buttonGroup.querySelector('#discard-btn');

        if (saveBtn) {
            saveBtn.addEventListener('click', onSaveClick);
        }
        if (discardBtn) {
            // Asumsi discard hanya kembali ke halaman index
            discardBtn.addEventListener('click', () => {
                window.location.href = '/RFQ/Index';
            });
        }
    }

    const rfqIdInput = document.querySelector('input[name="RFQID_FromEdit"]');
    if (rfqIdInput && rfqIdInput.value) {
        // Jika halaman dimuat dengan ID RFQ (artinya sudah tersimpan),
        // maka nonaktifkan semua field dan ubah tombolnya.
        disableAllFormFields();
        renderSendEditDiscard();
    }
});

function populateEndUserDropdown(customerId) {
    const endUserSelect = $('#endUserDropdown'); // Menggunakan jQuery selector agar lebih mudah
    endUserSelect.empty(); // Kosongkan pilihan lama
    endUserSelect.prop('disabled', true); // Nonaktifkan selama proses loading

    if (customerId && customerId !== "" && customerId !== "0") {
        endUserSelect.append($('<option></option>').val('').text('Loading...'));

        $.ajax({
            url: '/RFQ/GetContactPersonsByCustomerId', // URL ke action di RFQController
            type: 'GET',
            data: { customerId: customerId },
            success: function (data) {
                endUserSelect.empty();
                endUserSelect.append($('<option></option>').val('').text('-- Pilih End User --'));
                if (data && data.length > 0) {
                    $.each(data, function (index, item) {
                        endUserSelect.append($('<option></option>').val(item.value).text(item.text));
                    });
                } else {
                    endUserSelect.append($('<option></option>').val('').text('Tidak ada kontak'));
                }
                endUserSelect.prop('disabled', false); // Aktifkan kembali dropdown
            },
            error: function () {
                endUserSelect.empty();
                endUserSelect.append($('<option></option>').val('').text('Error memuat data'));
            }
        });
    } else {
        endUserSelect.append($('<option></option>').val('').text('-- Pilih Perusahaan --'));
    }
}