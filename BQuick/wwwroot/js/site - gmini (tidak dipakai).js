// File: wwwroot/js/rfq-create-full-integrated.js

// Variabel global itemMasterOptionsHtml, userOptionsHtml, surveyCategoryOptionsHtml, window.companies
// DIHARAPKAN SUDAH DIDEFINISIKAN DAN DIISI DI FILE CSHTML SEBELUM SCRIPT INI.

$(document).ready(function () {
    // --- FUNGSI DARI JAVASCRIPT ANDA (YANG RELEVAN DAN TIDAK KONFLIK) ---
    function searchGlobalTable() {
        const input = document.getElementById("searchInput");
        if (!input) return;
        const filter = input.value.toLowerCase();
        const table = document.querySelector(".table-sortable");
        if (!table) return;
        const trs = table.getElementsByTagName("tr");
        for (let i = 1; i < trs.length; i++) {
            const tds = trs[i].getElementsByTagName("td");
            let match = false;
            for (let j = 0; j < tds.length; j++) {
                if (tds[j].textContent.toLowerCase().indexOf(filter) > -1) {
                    match = true; break;
                }
            }
            trs[i].style.display = match ? "" : "none";
        }
    }
    const searchInputEl = document.getElementById("searchInput");
    if (searchInputEl) { searchInputEl.addEventListener('keyup', searchGlobalTable); }

    function closeAllCustomDropdowns() {
        document.querySelectorAll('#createRfqFullForm .wrapp.active').forEach(wrapper => {
            wrapper.classList.remove('active');
        });
        document.querySelectorAll('#createRfqFullForm .option .has-sub.active').forEach(el => {
            el.classList.remove('active');
        });
    }

    function getCompanyCode(name) {
        if (!name || typeof name !== 'string') return '';
        return name.split(/\s+/).map(w => w[0]).filter(Boolean).join('').toUpperCase();
    }

    $('#createRfqFullForm').on('keydown', function (e) {
        if (e.key === 'Enter') {
            if (e.target.tagName !== 'TEXTAREA' && e.target.type !== 'submit' && e.target.type !== 'button' && !$(e.target).hasClass('allow-enter')) {
                e.preventDefault(); return false;
            }
        }
    });

    const hamburger = document.querySelector(".toggle-btn");
    const toggler = document.querySelector("#icon");
    if (hamburger && toggler) {
        hamburger.addEventListener("click", function () {
            const sidebar = document.querySelector("#sidebar");
            if (sidebar) sidebar.classList.toggle("expand");
            toggler.classList.toggle("bx-chevrons-right");
            toggler.classList.toggle("bx-chevrons-left");
        });
    }

    // --- Logika untuk Pop-up Add Customer (dari kode Anda) ---
    const addCustomerPopupBtn = document.getElementById('openAddCustomerPopupBtn'); // Tombol baru untuk membuka pop-up
    const customerFormPopUpEl = document.querySelector('.add-customer-form-pop-up');
    const addCustomerContactBtnInPopup = document.getElementById('add-customer-contact-btn');
    const customerContactFormPopUpInSection = customerFormPopUpEl ? customerFormPopUpEl.querySelector('.add-customer-contact-form-pop-up') : null;
    const customerContactFormOpenChevron = document.getElementById('customer-contact-form-open-chevron');
    const customerContactInfoPopUp = customerFormPopUpEl ? customerFormPopUpEl.querySelector('.show-customer-contact-information-form-pop-up') : null;
    const customerContactInfoCloseBtn = document.getElementById('customer-contact-information-form-open-minus');
    const customerContactInfoOpenChevron = document.getElementById('customer-contact-information-form-close-chevron');

    if (addCustomerPopupBtn && customerFormPopUpEl) {
        addCustomerPopupBtn.addEventListener('click', function () {
            customerFormPopUpEl.style.display = 'block';
            // Reset form di dalam pop-up
            $(customerFormPopUpEl).find('input, select, textarea').each(function () {
                if ($(this).is(':checkbox') || $(this).is(':radio')) $(this).prop('checked', false);
                else if ($(this).is(':file')) $(this).val(null);
                else $(this).val('');
            });
            if (customerContactFormPopUpInSection) customerContactFormPopUpInSection.style.display = 'none';
            if (addCustomerContactBtnInPopup) addCustomerContactBtnInPopup.style.display = 'block';
        });
    }
    $(document).on('click', '.add-customer-form-close-btn-direct', function () { // Tombol close di pop-up
        if (customerFormPopUpEl) customerFormPopUpEl.style.display = 'none';
    });

    if (addCustomerContactBtnInPopup && customerContactFormPopUpInSection) {
        addCustomerContactBtnInPopup.addEventListener('click', function () {
            $(customerContactFormPopUpInSection).find('input, select, textarea').val(''); // Reset sub-form
            customerContactFormPopUpInSection.style.display = 'block';
            addCustomerContactBtnInPopup.style.display = 'none';
            if (customerContactInfoPopUp) customerContactInfoPopUp.classList.add('active');
            if (customerContactInfoOpenChevron) customerContactInfoOpenChevron.style.display = 'none';
            if (customerContactInfoCloseBtn) customerContactInfoCloseBtn.style.display = 'inline-block';
        });
    }
    if (customerContactFormOpenChevron && customerContactFormPopUpInSection && addCustomerContactBtnInPopup) {
        customerContactFormOpenChevron.addEventListener('click', function () {
            customerContactFormPopUpInSection.style.display = 'none';
            addCustomerContactBtnInPopup.style.display = 'block';
        });
    }
    // ... (Sisa logika expand/collapse dan tab panel di dalam pop-up customer dari kode Anda) ...
    // ... (Event listener untuk .add-customer-form-save-btn di pop-up) ...
    $(document).on('click', '.add-customer-form-save-btn', function (e) {
        e.preventDefault();
        const companyName = $('#popupCustomerName').val(); // Ambil dari input di pop-up
        // Logika untuk menambahkan companyName ke dropdown #customerIdDropdown
        if (companyName) {
            const $customerDropdown = $('#customerIdDropdown');
            // Cek jika sudah ada, jika tidak, tambahkan (ini hanya demo UI, ID sebenarnya dari server)
            if (!$customerDropdown.find("option[text='" + companyName + "']").length) {
                $customerDropdown.append(new Option(companyName, "NEW_" + companyName.replace(/\s/g, ''), true, true)).trigger('change');
            } else {
                $customerDropdown.find("option[text='" + companyName + "']").prop('selected', true).trigger('change');
            }
        }
        if (customerFormPopUpEl) customerFormPopUpEl.style.display = 'none';
    });


    // --- Logika Dropdown Kustom (Company, Resource, Category, Opportunity) dari HTML Anda ---
    // Ini akan mengontrol UI dropdown kustom Anda.
    // Penting: Nilai yang dipilih dari dropdown kustom ini HARUS di-transfer ke
    // elemen <select asp-for...> standar agar bisa di-submit ke server.
    function setupCustomDropdown(wrapperSelector, standardSelectName) {
        const wrapper = document.querySelector(wrapperSelector);
        if (!wrapper) return;

        const selectBtn = wrapper.querySelector(".select-btn");
        const searchInp = wrapper.querySelector(".search input");
        const optionsList = wrapper.querySelector(".option");
        const standardSelect = document.querySelector(`select[name="${standardSelectName}"]`);

        // Isi opsi kustom dari select standar (jika ada)
        if (standardSelect && optionsList && $(optionsList).children().length === 0) { // Hanya isi jika kosong
            Array.from(standardSelect.options).forEach(opt => {
                if (opt.value) { // Jangan ambil placeholder
                    let li = document.createElement("li");
                    li.textContent = opt.text;
                    li.dataset.value = opt.value; // Simpan value asli
                    li.onclick = function () { updateCustomDropdownSelection(this, wrapper, standardSelectName); };
                    optionsList.appendChild(li);
                }
            });
        }

        if (selectBtn) {
            selectBtn.addEventListener("click", function (e) {
                e.stopPropagation();
                const isActive = wrapper.classList.contains("active");
                closeAllCustomDropdowns(); // Fungsi dari kode Anda
                if (!isActive) wrapper.classList.add("active");
            });
        }

        if (searchInp && optionsList) {
            searchInp.addEventListener("keyup", () => {
                let searchWord = searchInp.value.toLowerCase();
                optionsList.innerHTML = ""; // Kosongkan
                // Filter dari opsi select standar
                if (standardSelect) {
                    Array.from(standardSelect.options).forEach(opt => {
                        if (opt.value && opt.text.toLowerCase().includes(searchWord)) {
                            let li = document.createElement("li");
                            li.textContent = opt.text;
                            li.dataset.value = opt.value;
                            li.onclick = function () { updateCustomDropdownSelection(this, wrapper, standardSelectName); };
                            optionsList.appendChild(li);
                        }
                    });
                }
            });
        }
        // Klik di luar dropdown kustom akan menutupnya
        document.addEventListener('click', function (e) {
            if (!wrapper.contains(e.target)) {
                wrapper.classList.remove("active");
            }
        });
    }

    function updateCustomDropdownSelection(selectedLi, wrapper, standardSelectName) {
        const selectBtn = wrapper.querySelector(".select-btn span");
        const standardSelect = document.querySelector(`select[name="${standardSelectName}"]`);
        const searchInp = wrapper.querySelector(".search input");

        if (selectBtn) selectBtn.innerText = selectedLi.textContent;
        if (standardSelect) {
            standardSelect.value = selectedLi.dataset.value || selectedLi.textContent; // Gunakan data-value jika ada
            $(standardSelect).trigger('change'); // Trigger change untuk AJAX atau validasi
        }
        if (searchInp) searchInp.value = "";
        wrapper.classList.remove("active");
        // Isi ulang opsi jika perlu
        // const optionsList = wrapper.querySelector(".option");
        // if(standardSelect && optionsList) { /* ... logika isi ulang opsi ... */ }
    }

    // Inisialisasi untuk dropdown kustom Anda jika masih ada di HTML
    // setupCustomDropdown("#createRfqFullForm .company-dropdown", "CustomerID"); // Jika Company Name adalah kustom
    // setupCustomDropdown("#createRfqFullForm .resource-dropdown", "Resource");
    // setupCustomDropdown("#createRfqFullForm .project-type-dropdown", "RFQCategoryID");
    // setupCustomDropdown("#createRfqFullForm #opportunity-dropdown", "RFQOpportunityID");


    // Logika Due Date otomatis
    $('input[name="RequestDate"]').on('change', function () {
        const requestDateVal = $(this).val();
        if (requestDateVal) {
            const requestDate = new Date(requestDateVal);
            requestDate.setDate(requestDate.getDate() + 14); // Default 14 hari
            $('input[name="DueDate"]').val(requestDate.toISOString().split('T')[0]);
        } else {
            $('input[name="DueDate"]').val('');
        }
    });

    // Tampilkan/Sembunyikan PIC Personal berdasarkan pilihan Resource
    $('#resourceDropdown').on('change', function () {
        if ($(this).val() === 'Personal') {
            $('#picPersonalSection').show();
        } else {
            $('#picPersonalSection').hide();
            $('select[name="PersonalResourceEmployeeID"]').val(''); // Kosongkan pilihan PIC
        }
    }).trigger('change'); // Panggil saat load untuk set state awal


    // --- Logika Attachment File (dari kode Anda, disesuaikan untuk form utama) ---
    let uploadedRfqFiles = [];
    const rfqFormUpload = document.querySelector('#createRfqFullForm .form-upload');
    const rfqFileInput = document.querySelector("#createRfqFullForm input.file-input[name='rfqHeaderAttachments']");
    const rfqAttachedFilesContainer = document.querySelector('#createRfqFullForm #attached-files-display');
    const rfqAttachmentCount = document.querySelector('#createRfqFullForm .form-upload .attachment-count');

    function createRfqFileInfo(file, nameOfFile) {
        let iconClass = 'fas fa-file';
        if (file.type.startsWith('image/')) iconClass = 'fas fa-file-image';
        else if (file.type.startsWith('application/pdf')) iconClass = 'fas fa-file-pdf';
        else if (file.type.startsWith('application/msword') || file.type.startsWith('application/vnd.openxmlformats-officedocument.wordprocessingml.document')) iconClass = 'fas fa-file-word';

        let fileTotal = Math.floor(file.size / 1024);
        let fileSize = (fileTotal < 1000) ? fileTotal + " KB" : (file.size / (1024 * 1024)).toFixed(2) + " MB";
        const fileInfo = document.createElement('div');
        fileInfo.classList.add('row', 'mb-1', 'p-1', 'border', 'rounded', 'bg-light', 'align-items-center');
        fileInfo.innerHTML = `
            <div class="col-1 d-flex align-items-center justify-content-center"><i class="${iconClass} fa-lg"></i></div>
            <div class="col-7 d-flex align-items-center">
                <div class="details">
                    <span class="name d-block text-truncate" title="${file.name}">${nameOfFile}</span>
                    <span class="size small text-muted">${fileSize}</span>
                </div>
            </div>
            <div class="col-4 d-flex align-items-center justify-content-end button-function">
                <button type="button" class="btn btn-outline-danger btn-sm delete-rfq-file-btn" title="Hapus"><i class="fas fa-times"></i></button>
            </div>`;
        // Tombol download bisa ditambahkan jika perlu
        fileInfo.querySelector('.delete-rfq-file-btn').addEventListener('click', function () {
            // Hapus dari array dan dari input file (ini bagian yang tricky)
            const fileIndex = uploadedRfqFiles.findIndex(f => f.name === file.name && f.size === file.size);
            if (fileIndex > -1) uploadedRfqFiles.splice(fileIndex, 1);
            fileInfo.remove();
            updateRfqFileCount();
            // Untuk benar-benar menghapus dari FileList input, perlu dibuat FileList baru
            const dt = new DataTransfer();
            uploadedRfqFiles.forEach(f => dt.items.add(f));
            if (rfqFileInput) rfqFileInput.files = dt.files;
        });
        return fileInfo;
    }
    function updateRfqFileCount() {
        if (rfqAttachmentCount) rfqAttachmentCount.textContent = uploadedRfqFiles.length;
        if (rfqAttachedFilesContainer) rfqAttachedFilesContainer.style.display = uploadedRfqFiles.length > 0 ? 'block' : 'none';
    }

    if (rfqFormUpload && rfqFileInput && rfqAttachedFilesContainer && rfqAttachmentCount) {
        rfqFormUpload.addEventListener("click", () => rfqFileInput.click());
        rfqFileInput.addEventListener('change', () => {
            const currentFiles = Array.from(rfqFileInput.files);
            uploadedRfqFiles = []; // Reset array setiap kali ada perubahan
            if (rfqAttachedFilesContainer) rfqAttachedFilesContainer.innerHTML = ''; // Bersihkan tampilan

            if (currentFiles.length > 5) {
                alert('Maksimal 5 file attachment.');
                rfqFileInput.value = ''; // Reset input
                updateRfqFileCount();
                return;
            }

            currentFiles.forEach(file => {
                if (file.size > 5 * 1024 * 1024) {
                    alert(`File "${file.name}" lebih dari 5MB dan tidak akan diunggah.`);
                } else {
                    uploadedRfqFiles.push(file); // Tambahkan ke array yang akan di-submit
                    let fileNameDisplay = file.name.length > 25 ? file.name.substring(0, 22) + "..." : file.name;
                    rfqAttachedFilesContainer.appendChild(createRfqFileInfo(file, fileNameDisplay));
                }
            });
            // Update FileList di input agar hanya file valid yang terkirim
            const dt = new DataTransfer();
            uploadedRfqFiles.forEach(f => dt.items.add(f));
            rfqFileInput.files = dt.files;
            updateRfqFileCount();
        });
    }

    // --- FUNGSI INTI DARI rfq-create-full.js (MENGGUNAKAN JQUERY) ---
    function initializeDynamicPlugin(selector) { /* Placeholder */ }

    $('#customerIdDropdown').on('change', function () {
        var customerId = $(this).val();
        var $contactPersonDropdown = $('#contactPersonIdDropdown');
        $contactPersonDropdown.empty().append('<option value="">Memuat...</option>');
        if (customerId) {
            $.ajax({
                url: '/RFQ/GetContactPersonsByCustomerId',
                type: 'GET', data: { customerId: customerId },
                success: function (data) {
                    $contactPersonDropdown.empty().append('<option value="">-- Pilih End User --</option>');
                    $.each(data, function (_, item) { $contactPersonDropdown.append($('<option>', { value: item.value, text: item.text })); });
                },
                error: function () { $contactPersonDropdown.empty().append('<option value="">Gagal memuat</option>'); }
            });
        } else {
            $contactPersonDropdown.empty().append('<option value="">-- Pilih Customer dulu --</option>');
        }
    });

    function addRowToTable(tableId, rowIndexNamePrefix, rowHtmlGenerator) {
        var $tableBody = $(tableId + " tbody");
        var itemCount = $tableBody.find("tr").length;
        var newRowHtml = rowHtmlGenerator(itemCount, rowIndexNamePrefix);
        $tableBody.append(newRowHtml);
        $tableBody.find("tr:last-child select.item-master-dropdown").each(function () {
            $(this).html(window.itemMasterOptionsHtml || '<option value="">Error: Opsi Item Master tidak terdefinisi</option>');
        });
        $tableBody.find("tr:last-child select.user-pic-dropdown").each(function () {
            $(this).html(window.userOptionsHtml || '<option value="">Error: Opsi User tidak terdefinisi</option>');
        });
        $tableBody.find("tr:last-child select.survey-category-dropdown").each(function () {
            $(this).html(window.surveyCategoryOptionsHtml || '<option value="">Error: Opsi Kategori Survey tidak terdefinisi</option>');
        });
        updateRemoveButtonsVisibility(tableId);
        reparseFormValidation();
    }

    $("#createRfqFullForm").on("click", ".remove-row", function () {
        var $table = $(this).closest('table');
        $(this).closest("tr").remove();
        // Update nomor urut setelah menghapus
        $table.find('tbody tr').each(function (index) {
            $(this).find('td.row-number').text(index + 1);
        });
        updateRemoveButtonsVisibility('#' + $table.attr('id'));
        reparseFormValidation();
    });

    function updateRemoveButtonsVisibility(tableSelector) {
        var $tableRows = $(tableSelector + " tbody tr");
        var rowCount = $tableRows.length;
        $tableRows.each(function (index) {
            var $removeButton = $(this).find(".remove-row");
            if (index === 0 && rowCount === 1 && !$(tableSelector).hasClass('allow-empty-table')) {
                $removeButton.hide();
            } else {
                $removeButton.show();
            }
        });
        if (rowCount === 1 && !$(tableSelector).hasClass('allow-empty-table')) {
            $(tableSelector + " tbody tr:first-child .remove-row").hide();
        } else if (rowCount > 1 || (rowCount === 1 && $(tableSelector).hasClass('allow-empty-table'))) {
            $(tableSelector + " tbody tr .remove-row").show();
        }
    }

    function reparseFormValidation() {
        var $form = $("#createRfqFullForm");
        if ($form.length && typeof $.validator !== 'undefined' && typeof $.validator.unobtrusive !== 'undefined') {
            $form.removeData("validator").removeData("unobtrusiveValidation");
            $.validator.unobtrusive.parse($form);
        }
    }

    $("#addNoteRowButton").on("click", function () {
        addRowToTable("#notesTable", "NotesSectionItems", function (index, prefix) {
            return `
                <tr>
                    <td class="row-number">${index + 1}</td>
                    <td><input name="${prefix}[${index}].ItemName" class="form-control form-control-sm size" /></td>
                    <td><textarea name="${prefix}[${index}].ItemDescription" class="form-control form-control-sm size" rows="1"></textarea></td>
                    <td><input name="${prefix}[${index}].Quantity" type="number" value="1" class="form-control form-control-sm text-end size" /></td>
                    <td><input name="${prefix}[${index}].UoM" value="Unit" class="form-control form-control-sm size tengah" /></td>
                    <td><input name="${prefix}[${index}].BudgetTarget" type="number" step="any" class="form-control form-control-sm text-end size" /></td>
                    <td><input name="${prefix}[${index}].LeadTimeTarget" class="form-control form-control-sm size tengah" /></td>
                    <td class="text-center align-middle delete"><button type="button" class="btn btn-danger btn-sm remove-row" title="Hapus Note"><i class="fas fa-trash-alt"></i></button></td>
                </tr>`;
        });
    });

    $("#addRfqItemRowButton").on("click", function () {
        if (typeof itemMasterOptionsHtml === 'undefined') { console.error("itemMasterOptionsHtml is not defined."); return; }
        addRowToTable("#rfqItemTable", "ItemListSectionItems", function (index, prefix) {
            return `
                <tr>
                    <td class="row-number">${index + 1}</td>
                    <td class="name"><select name="${prefix}[${index}].ItemID" class="form-select form-select-sm item-master-dropdown">${itemMasterOptionsHtml}</select><span data-valmsg-for="${prefix}[${index}].ItemID" class="text-danger"></span></td>
                    <td class="desc"><input name="${prefix}[${index}].Details" class="form-control form-control-sm size" placeholder="Deskripsi Item (auto)" readonly /></td>
                    <td class="qty"><input name="${prefix}[${index}].Quantity" type="number" value="1" class="form-control form-control-sm text-end size" /></td>
                    <td class="uom"><input name="${prefix}[${index}].UoM" value="Unit" class="form-control form-control-sm size tengah" /></td>
                    <td class="price"><input name="${prefix}[${index}].TargetUnitPrice" type="number" step="any" class="form-control form-control-sm text-end size" /></td>
                    <td class="notes"><input name="${prefix}[${index}].Notes" class="form-control form-control-sm size" /></td>
                    <td class="details"><input name="${prefix}[${index}].Details" class="form-control form-control-sm size" /></td>
                    <td class="warranty"><input name="${prefix}[${index}].SalesWarranty" class="form-control form-control-sm size" /></td>
                    <td class="delete text-center align-middle"><button type="button" class="btn btn-danger btn-sm remove-row" title="Hapus Item"><i class="fas fa-trash-alt"></i></button></td>
                </tr>`;
        });
        // Event listener untuk mengisi UoM dan Deskripsi saat item dipilih
        $('#rfqItemTable').on('change', '.item-master-dropdown', function () {
            var selectedOption = $(this).find('option:selected');
            var uom = selectedOption.data('uom') || 'Unit';
            var desc = selectedOption.data('desc') || '';
            var $row = $(this).closest('tr');
            $row.find('.uom input').val(uom);
            $row.find('.desc input').val(desc);
        });
    });

    $("#addPurchasingRequestRowButton").on("click", function () {
        if (typeof itemMasterOptionsHtml === 'undefined' || typeof userOptionsHtml === 'undefined') { console.error("itemMasterOptionsHtml or userOptionsHtml is not defined."); return; }
        addRowToTable("#purchasingRequestTable", "PurchasingRequestSectionItems", function (index, prefix) {
            return `
                <tr>
                    <td class="row-number">${index + 1}</td>
                    <td><select name="${prefix}[${index}].ItemID_IfExists" class="form-select form-select-sm item-master-dropdown">${itemMasterOptionsHtml}</select></td>
                    <td><input name="${prefix}[${index}].RequestedItemName" class="form-control form-control-sm" /></td>
                    <td><input name="${prefix}[${index}].RequestedItemDescription" class="form-control form-control-sm" /></td>
                    <td><input name="${prefix}[${index}].Quantity" type="number" value="1" class="form-control form-control-sm text-end" /></td>
                    <td><input name="${prefix}[${index}].UoM" value="Unit" class="form-control form-control-sm" /></td>
                    <td><input name="${prefix}[${index}].ReasonForRequest" class="form-control form-control-sm" /></td>
                    <td><input name="${prefix}[${index}].SalesNotes" class="form-control form-control-sm" /></td>
                    <td><select name="${prefix}[${index}].AssignedToPurchasingUserID" class="form-select form-select-sm user-pic-dropdown">${userOptionsHtml}</select></td>
                    <td class="text-center align-middle"><button type="button" class="btn btn-danger btn-sm remove-row" title="Hapus Request"><i class="fas fa-trash-alt"></i></button></td>
                </tr>`;
        });
    });

    $("#addSurveyRequestRowButton").on("click", function () {
        if (typeof surveyCategoryOptionsHtml === 'undefined' || typeof userOptionsHtml === 'undefined') { console.error("surveyCategoryOptionsHtml or userOptionsHtml is not defined."); return; }
        addRowToTable("#surveyRequestTable", "SurveySectionItems", function (index, prefix) {
            return `
                <tr>
                    <td class="row-number">${index + 1}</td>
                    <td><select name="${prefix}[${index}].SurveyCategoryID" class="form-select form-select-sm survey-category-dropdown">${surveyCategoryOptionsHtml}</select></td>
                    <td><input name="${prefix}[${index}].SurveyName" class="form-control form-control-sm" /></td>
                    <td><input name="${prefix}[${index}].CustomerPICName" class="form-control form-control-sm" /></td>
                    <td><select name="${prefix}[${index}].TechnicalUserIDs" class="form-select form-select-sm user-pic-dropdown" multiple size="3">${userOptionsHtml}</select><small class="form-text text-muted d-block" style="font-size:0.75rem;">Ctrl/Cmd+klik untuk multi-pilih.</small></td>
                    <td><input name="${prefix}[${index}].RequestedDateTime" type="datetime-local" class="form-control form-control-sm" /></td>
                    <td><input name="${prefix}[${index}].LocationDetails" class="form-control form-control-sm" /></td>
                    <td><input name="${prefix}[${index}].SalesNotesInternal" class="form-control form-control-sm" /></td>
                    <td class="text-center align-middle"><button type="button" class="btn btn-danger btn-sm remove-row" title="Hapus Survey"><i class="fas fa-trash-alt"></i></button></td>
                </tr>`;
        });
    });

    ["#notesTable", "#rfqItemTable", "#purchasingRequestTable", "#surveyRequestTable"].forEach(function (tableId) {
        if ($(tableId).length) {
            updateRemoveButtonsVisibility(tableId);
            $(tableId).find('tbody tr').each(function (index) { $(this).find('td.row-number').text(index + 1); });
        }
    });

    var $validationSummary = $(".validation-summary-errors");
    if ($validationSummary.length && $validationSummary.find("ul > li").length > 0 && $validationSummary.find("ul > li:not([style*='display: none'])").length > 0) {
        $validationSummary.show();
    } else if ($validationSummary.length) {
        $validationSummary.hide();
    }

});
