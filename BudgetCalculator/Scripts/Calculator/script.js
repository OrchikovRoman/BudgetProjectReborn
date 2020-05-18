var $categories = $('#categories');

const totalBalance = document.querySelector('.total__balance'),
    totalMoneyIncome = document.querySelector('.total__money-income'),
    totalMoneyExpenses = document.querySelector('.total__money-expenses'),
    historyList = document.querySelector('.history__list'),
    form = document.getElementById('form'),
    operationDescription = document.querySelector('.operation__description'),
    operationAmount = document.querySelector('.operation__amount'),
    operationDateOperation = document.querySelector('.operation__dateOperation'),
    operationCategoryId = document.querySelector('.operation__categoryId'),
    operationUserId = document.querySelector('.operation__userId');

let dbOperationChart;
let dbCategoriesChart;
let dbOperation;


const calculationOfDataChart = () => {
    var expensesArr = [];
    var partSummArr = [];
    var partNameArr = [];

    for( let i=1; i < dbOperationChart.length; i++) {
        const summ = dbOperationChart.filter((item) => item.CategoryId == i)
        .reduce((result, item) => result + item.Amount, 0);
        if(summ<0) {
            expensesArr.push(summ*(-1));
            const name = dbCategoriesChart.find((el) => el.Id == i);
            partNameArr.push(name.Name);
        }
    }

    const sumAllExpenses = expensesArr.reduce((result, item) => result + item, 0);
    for( let i=0; i < expensesArr.length; i++) {
        const partSumm = Math.round(((expensesArr[i]*100)/sumAllExpenses)*100)/100;
        partSummArr.push(partSumm);
    }

    let dataChart = [];
    for(var i = 0; i< partNameArr.length; i++){
    var resultvar = { y : partSummArr[i], name: partNameArr[i] }
    dataChart.push(resultvar)
    }

    Highcharts.chart('container', {
        chart: {
          plotBackgroundColor: null,
          plotBorderWidth: null,
          plotShadow: false,
          type: 'pie'
        },
        title: {
          text: 'Expenses donut chart'
        },
        tooltip: {
          pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
        },
        accessibility: {
          point: {
            valueSuffix: '%'
          }
        },
        plotOptions: {
          pie: {
            allowPointSelect: true,
            cursor: 'pointer',
            dataLabels: {
              enabled: true,
              format: '<b>{point.name}</b>: {point.percentage:.1f} %'
            }
          }
        },
        series: [{
          name: 'Expense',
          colorByPoint: true,
          data: dataChart
        }]
      });
};

const renderOperation = (operation)=>{

    const className = operation.Amount < 0 ? 
    'history__item-minus' :
    'history__item-plus';

    const listItem = document.createElement('li');
    listItem.classList.add('history__item');
    listItem.classList.add(className);

    listItem.innerHTML = `${operation.Description}
        <span class="history__money">${operation.Amount} ₴</span>
        <button class="history_delete" data-id="${operation.Id}">x</button>
    `;

    historyList.append(listItem);
};

const updateBalance = () => {

    const resultIncome = dbOperation
    .filter((item) => item.Amount > 0)
    .reduce((result, item) => result + item.Amount, 0);
        
    const resultExpenses = dbOperation
    .filter((item) => item.Amount < 0)
    .reduce((result, item) => result + item.Amount, 0);

    totalMoneyIncome.textContent = resultIncome + ' ₴';
    totalMoneyExpenses.textContent = resultExpenses + ' ₴';
    totalBalance.textContent = (resultIncome + resultExpenses) + ' ₴';

};

const addOperation = (event) => {
    event.preventDefault();

    const operationDescriptionValue = operationDescription.value,
        operationAmountValue = operationAmount.value,
        operationDateOperationValue = operationDateOperation.value,
        operationCategoryIdValue = operationCategoryId.value,
        operationUserIdValue = operationUserId.value;

        operationDescription.style.borderColor = '';
        operationAmount.style.borderColor = '';

    if(operationDescriptionValue && operationAmountValue &&
        operationDateOperationValue && operationCategoryIdValue && operationUserIdValue) {
        
       const operation = {
           description: operationDescriptionValue,
           amount: +operationAmountValue,
       }

       var model = {
        Amount: operationAmount.value,
        Description: operationDescription.value,
        DateOperation: operationDateOperation.value,
        CategoryId: operationCategoryId.value,
        UserId: operationUserId.value,
       }

       $.ajax( {
            type: 'POST',
            url: 'http://local.budgetcalculatorapi/api/Operation',
            data: model,
            success: function(data) {
                dbOperation.push(operation);
                init();
            },
            error: () => { alert('error saving operation'); },
       })
        
    } else {
        if(!operationDescriptionValue) operationDescription.style.borderColor = 'red';
        if(!operationAmountValue) operationAmount.style.borderColor = 'red';
        if(!operationDateOperationValue) operationDateOperation.style.borderColor = 'red';
        if(!operationCategoryIdValue) operationCategoryId.style.borderColor = 'red';
        if(!operationUserIdValue) operationUserId.style.borderColor = 'red';
    }
    
    operationDescription.value = '';
    operationAmount.value = '';
    operationDateOperation.value = '';
    operationCategoryId.value = '';
    operationUserId.value = '';
};

const deleteOperation = (event) => {
    const target = event.target;
    if(target.classList.contains('history_delete')) {
        $.ajax({
            type: 'DELETE',
            url: `http://local.budgetcalculatorapi/api/Operation/${target.dataset.id}`,
            success: function(item) {
                dbOperation = dbOperation
                .filter(operation => operation.id !== target.dataset.id);
                init();
            },
            error: () => { alert('error delete operation'); },
        })
    }
};

const init = () => {
    historyList.textContent = '';

    $.ajax({
        type: 'GET',
        url: 'http://local.budgetcalculatorapi/api/Operation',
        success: (operation) => {
            dbOperationChart = operation;
            dbOperation = operation;

            dbOperation.forEach(renderOperation);
            updateBalance();
        },
        error: () => { alert('error loading operations for chart'); }
    });
    $.ajax({
        type: 'GET',
        url: 'http://local.budgetcalculatorapi/api/Category',
        success: (category) => {
            $.each(category, (i, item) => {
                $categories.append(`<option value="${item.Id}">${item.Name}</option>`)
            });

            dbCategoriesChart = category;
            calculationOfDataChart();
        },
        error: () => { alert('error loading categories for chart'); }
    });
};

form.addEventListener('submit', addOperation);
historyList.addEventListener('click', deleteOperation);

init();

