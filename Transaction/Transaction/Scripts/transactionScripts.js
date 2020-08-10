
$(document).ready(function () {
	var table = $('#transactions_table').DataTable({
		columnDefs: [
			{
				targets: -1,
				className: 'dt-body-center'
			}
		],
		searching: false,
		select: {
			style: 'single'
		}
	});

	$('#transactions_table tbody').on('click', 'tr', function () {
		$(this).toggleClass('selected');
	});

	$("body").on("click", "#btnSave", function () {
		var tableData = table.rows('.selected').data()[0];
		if (tableData) {
			let bankId = $('#bankId').val();
			var accountSender = {
				Id: tableData[0],
				AccountType: { Name: tableData[1] },
				Balance: tableData[2],
				Bank: { Id: bankId }
			};

			$('#transaction-modal').modal({ showClose: false });
			$('#sumGroup').css("visibility", "hidden");

			$.ajax({
				type: "POST",
				url: "/Home/GetBanksList",
				contentType: "application/json; charset=utf-8",
				dataType: "json",
				success: function (jsonData) {
					var data;
					try {
						var data = jQuery.parseJSON(jsonData);
					}
					catch (ex) {
						window.main.Logger().Error(ex);
						data = { Banks: [] };
					}
					var selectBank = $('#selectBank');
					$.each(data.Banks, function () {
						selectBank.append($("<option></option>")
							.attr("value", this.Id)
							.text(this.Name));
					});

					$('#selectBtn').click(function () {
						var receiverBankId = $('#selectBank').val();
						$.ajax({
							type: "POST",
							url: "/Home/GetJsonBankAccounts",
							data: JSON.stringify({ Id: receiverBankId }),
							contentType: "application/json; charset=utf-8",
							dataType: "json",
							success: function (jsonData) {
								var accountsData;
								try {
									var accountsData = jQuery.parseJSON(jsonData);
								}
								catch (ex) {
									window.main.Logger().Error(ex);
									accountsData = { Accounts: [] };
								}
								var accounts = accountsData.Accounts;
								var modalTable = $('#table_modal').DataTable({
									data: accounts,
									columns: [
										{ data: 'Id' },
										{ data: 'AccountType.Name' },
										{ data: 'Balance' }],
									searching: false,
									select: {
										style: 'single'
									}
								});

								$('#table_modal tbody').on('click', 'tr', function () {
									$(this).toggleClass('selected');
									$('#sumGroup').css("visibility", "visible");
								});

								$('#saveBtn').click(function () {
									var receiverData = modalTable.rows('.selected').data()[0];
									if (receiverData) {
										var accountReceiver = receiverData;

										var sum = $('#sum').val();

										$.ajax({
											type: "POST",
											url: "/Home/CreateTransaction",
											data: JSON.stringify({ Sender: accountSender, Receiver: accountReceiver, Sum: sum }),
											contentType: "application/json; charset=utf-8",
											dataType: "json",
											success: function (result) {
												$('#modal-body').html(result);
											}
										});
									}

								});
							}
						});

					});
				}
			});
		}
	});
});
