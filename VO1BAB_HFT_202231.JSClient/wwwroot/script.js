let carbrand = [];
/*let car = [];*/


getData();


//async function getData() {
//    await fetch("http://localhost:50437/carbrand")
//        .then(x => x.json())
//        .then(y => {
//            carbrand = y;
//            display();


//        });
//}

async function getData() {
    const resp1 = await fetch("http://localhost:50437/Carbrand");
    const data1 = await resp1.json();


    //const resp2 = await fetch("http://localhost:50437/Cars");
    //const data2 = await resp2.json();
    
    carbrand = data1;
   /* car = data2;*/
   
    display();
    display2();
}

function display() {
    document.querySelector("#resultarea").innerHTML = "";
    carbrand.forEach(t => {
        document.querySelector("#resultarea").innerHTML  += 
            "<tr><td>" + t.carBrandID + "</td><td>" + t.name + "</td><td>" +
            `<button type="button" onclick="remove(${t.carBrandID})">Delete</button>` + "</td ></tr > ";
    })
    
}

//function display2() {
//    document.querySelector("#carsarea").innerHTML = "";
//    car.forEach(t => {
//        document.querySelector("#carsarea").innerHTML +=
//            "<tr><td>" + t.carsID + "</td><td>" + t.carBrandID + "</td><td>" + t.licensePlateNumber + "</td><td>" + t.year + "</td><td>" + t.type + "</td><td>" + t.performanceInHP + "</td><td>" + t.carBrand.carBrandID + "</td><td>" + t.carBrand.name + "</td><td>" +
//            `<button type="button" onclick="remove(${t.CarsID})">Delete</button>` + "</td ></tr > ";
//    })

//}



function remove(id) {
    fetch('http://localhost:50437/carbrand/' + id, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
        },
        body: null
    })
        .then(response => response)
        .then(data => {

            console.log('Success:', data);
            getData();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}


function create() {
    let names = document.querySelector("#carbrandname").value;
    fetch('http://localhost:50437/carbrand', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                name: names
            }),
    })
        .then(response => response)
        .then(data => {

            console.log('Success:', data);
            getData();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
    
    
}


