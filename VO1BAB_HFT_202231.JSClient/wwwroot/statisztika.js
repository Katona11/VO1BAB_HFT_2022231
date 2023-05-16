let TheRentsCarBrand = [];
let BrandperRentsCountsMethod = [];

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
    display1();
    display2();


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