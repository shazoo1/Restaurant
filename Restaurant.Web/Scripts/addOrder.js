﻿
function fillUnselectedList() {
    var menu = document.getElementById('menu');
    for (var i = 0; i < unselected.length; i++) {
        var dishName = unselected[i].Name;
        var dishPrice = unselected[i].Price;
        var dishId = unselected[i].Id;
        var row = $('<tr><td>' + dishName + '</td><td>' +
            dishPrice + '</td><td><input type="button" value="Добавить"' +
            'onclick="addToOrder(this.id, this)" id=' + dishId + ' /></td></tr>');
        $('#menu').append(row);
    }
}
function addToOrder(id, row) {
    row.closest('tr').remove();
    var selectedDishIndex = unselected.findIndex(x => x.Id === id);
    var selectedDish = unselected[selectedDishIndex];
    selected.push({ Id : selectedDish.Id, Quantity : 0 });
    var counter = '<input type=number min="0" step="1" onchange="countSum(this)">'
    var rowToAdd = '<tr id="' + selectedDish.Id+'">' + '<td>' + selectedDish.Name + '</td><td id="price">' +
        selectedDish.Price + '</td><td>' + counter + '</td><td name="sum" id="sum">' +
        '</td></tr>';
    $('#dishesTable').append(rowToAdd);
    unselected.splice(selectedDishIndex, 1);
}
function countSum(counter) {
    var tr = $(counter).parent().parent();
    var price = ($(tr).find('#price')).text();
    var sumCell = $(tr).find('#sum');
    sumCell.text(price * counter.value);
    selected.find(x => x.Id === tr.attr('id')).Quantity = counter.value;
    countTotal();
}
function countTotal() {
    var sums = $('#dishesTable').find('*#sum');
    var total = 0;
    for (var i = 0; i < sums.length; i++) {
        total = total + (sums[i].innerText * 1);
    }
    $('#total').text(total);
}

