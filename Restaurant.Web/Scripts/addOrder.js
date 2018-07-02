﻿
function fillUnselectedList() {
    var menu = document.getElementById('menu');
    for (var i = 0; i < unselected.length; i++) {
        var dishName = unselected[i].Name;
        var dishPrice = unselected[i].Price;
        var dishId = unselected[i].Id;
        var dishDescription = unselected[i].Description;
        var row = $('<tr id="' + dishId + '" class="menu-table-row" onclick="addToOrder(this.id, this)"><td>' + dishName + '</td><td>' +
            dishPrice + '</td><td>'+ dishDescription +'</td></tr>');
        $('#menu').append(row);
    }
}
function addToOrder(id, row) {
    row.closest('tr').remove();
    var selectedDishIndex = unselected.findIndex(x => x.Id === id);
    var selectedDish = unselected[selectedDishIndex];
    selected.push({ Dish : selectedDish, Quantity : 0 });
    var counter = '<input type=number min="0" step="1" onchange="countSum(this)">'
    var deleteButton = '<input id="' + selectedDish.Id + '" type=button onclick="removeFromOrder(this.id, this)" value="Удалить"/>';
    var hiddenId = '<input type="hidden" name="Id" value="' + selectedDish.Id + '"/>';
    var hiddenQuantity = '<input type="hidden" name="Quantity" value=' + selectedDish.Quantity + '"/>';
    var rowToAdd = '<tr id="' + selectedDish.Id+'">' + '<td>' + selectedDish.Name + '</td><td id="price">' +
        selectedDish.Price + '</td><td>' + counter + '</td><td name="sum" id="sum">' +
        '</td><td>'+deleteButton+'</td></tr>';
    $('#dishesTable').append(rowToAdd);
    unselected.splice(selectedDishIndex, 1);
}

function removeFromOrder(id, button) {
    button.closest('tr').remove();
    var unselectedDishIndex = selected.findIndex(x => x.Dish.Id === id);
    var unselectedDish = selected[unselectedDishIndex].Dish;
    unselected.push(unselectedDish);
    var dishName = unselectedDish.Name;
    var dishPrice = unselectedDish.Price;
    var dishId = unselectedDish.Id;
    var dishDesc = unselectedDish.Description;
    var row = $('<tr id="' + dishId + '" class="menu-table-row" onclick="addToOrder(this.id, this)"><td>' + dishName + '</td><td>' +
        dishPrice + '</td><td>'+dishDesc+'</td></tr>');
    $('#menu').append(row);
    selected.splice(unselectedDishIndex, 1);
    countTotal();
}
function countSum(counter) {
    var tr = $(counter).parent().parent();
    var price = ($(tr).find('#price')).text();
    var sumCell = $(tr).find('#sum');
    sumCell.text(price * counter.value);
    selected.find(x => x.Dish.Id === tr.attr('id')).Quantity = counter.value;
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
function getModel() {
    var modelToSend = [];
    for (var i = 0; i < selected.length; i++) {
        dishId = selected[i].Dish.Id;
        dishQuantity = selected[i].Quantity;
        modelToSend.push({id:dishId, quantity:dishQuantity});
    }
    return modelToSend;
}

