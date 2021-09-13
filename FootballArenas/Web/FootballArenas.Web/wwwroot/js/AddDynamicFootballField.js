let fieldIndex = 0;

function addFootballField() {
    $("#fieldsContainer").append(`<div class='form-group'>Football field name: <input value='Football field ${fieldIndex + 1}' class='form-control' type='text' name='FootballFields[${fieldIndex}].Name' id='' /> Size: <input class='form-control' type='text'  name='FootballFields[${fieldIndex}].Size' id='' /> Recommended number of people: <input class='form-control' type='text' name='FootballFields[${fieldIndex}].RecommendedNumberOfPeople' id='' /> </div> <div class='divider py-1 bg-dark'></div>`);
    fieldIndex++;
}