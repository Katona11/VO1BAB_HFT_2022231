let TheRentsCarBrand = [];
let BrandperRentsCountsMethod = [];
let TheMostFamousBrand = [];
let AvarageHPperCar = [];
let YearStatistics = [];
getData();

async function getData() {
    let url1 = "http://localhost:50437/crudmethod/therentscarbrand";
    let response1 = await fetch(url1);
    let data1 = await response1.json();

    
    TheRentsCarBrand = data1;


    let url2 = "http://localhost:50437/CrudMethod/BrandperRentsCountsMethod";
    let response2 = await fetch(url2);
    let data2 = await response2.json();

    BrandperRentsCountsMethod = data2;


    let url3 = "http://localhost:50437/CrudMethod/TheMostFamousBrand";
    let response3 = await fetch(url3);
    let data3 = await response3.json();
    TheMostFamousBrand = data3;


    let url4 = "http://localhost:50437/CrudMethod/AvarageHPperCar";
    let response4 = await fetch(url4);
    let data4 = await response4.json();
    AvarageHPperCar = data4;


    let url5 = "http://localhost:50437/CrudMethod/YearStatistics";
    let response5 = await fetch(url5);
    let data5 = await response5.json();
    YearStatistics = data5;


    display1();
    display2();
    display3();
    display4();
    display5();


}


function display1() {
    document.querySelector("#theRentsCarBrand").innerHTML += "<ul>";
    TheRentsCarBrand.forEach(t =>
    {
        document.querySelector("#theRentsCarBrand").innerHTML += "<li>" + t + "</li>"
    }) 
    document.querySelector("#theRentsCarBrand").innerHTML += "</ul>";
}

function display2() {
    document.querySelector("#BrandperRentsCountsMethod").innerHTML += "<ul>";
    BrandperRentsCountsMethod.forEach(t => {
        document.querySelector("#BrandperRentsCountsMethod").innerHTML += "<li>" + t.brand + "(" + t.count + ")" + "</li>";
    })
    document.querySelector("#BrandperRentsCountsMethod").innerHTML += "</ul>";
}

function display3() {
    document.querySelector("#TheMostFamousBrand").innerHTML += "<ul>";
    TheMostFamousBrand.forEach(t => {
        document.querySelector("#TheMostFamousBrand").innerHTML += "<li>" + t.name + " - " + t.count  + "</li>";
    })
    document.querySelector("#TheMostFamousBrand").innerHTML += "</ul>";
}

function display4() {
    document.querySelector("#AvarageHPperCar").innerHTML += "<ul>";
    AvarageHPperCar.forEach(t => {
        document.querySelector("#AvarageHPperCar").innerHTML += "<li>" + t.name + " - " + Math.round(t.avarage,2) + "</li>";
    })
    document.querySelector("#AvarageHPperCar").innerHTML += "</ul>";
}

function display5() {
    document.querySelector("#YearStatistics").innerHTML += "<ul>";
    YearStatistics.forEach(t => {
        document.querySelector("#YearStatistics").innerHTML += "<li>" + t.year + " - " + t.count + "</li>";
    })
    document.querySelector("#YearStatistics").innerHTML += "</ul>";
}