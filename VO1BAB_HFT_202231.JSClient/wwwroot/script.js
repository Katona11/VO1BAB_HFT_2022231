let carbrand = [];
/*let car = [];*/

let carbrandidtoupdate = -1;


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
    
}

function display() {
    document.querySelector("#resultarea").innerHTML = "";
    carbrand.forEach(t => {
        document.querySelector("#resultarea").innerHTML  += 
            "<tr><td>" + t.carBrandID + "</td><td>" + t.name + "</td><td>" +
            `<button type="button" onclick="remove(${t.carBrandID})">Delete</button>`+
            `<button type="button" onclick="showupdate(${t.carBrandID})">Update</button>` + "</td ></tr > ";
    })
    
}



function showupdate(id) {
    document.querySelector("#carbrandnameupdate").value = carbrand.find(t => t['carBrandID'] == id)['name'];
    document.querySelector("#updateformdiv").style.display = 'flex';
    carbrandidtoupdate = id;
}


//function display2() {
//    document.querySelector("#carsarea").innerHTML = "";
//    car.forEach(t => {
//        document.querySelector("#carsarea").innerHTML +=
//            "<tr><td>" + t.carsID + "</td><td>" + t.carBrandID + "</td><td>" + t.licensePlateNumber + "</td><td>" + t.year + "</td><td>" + t.type + "</td><td>" + t.performanceInHP + "</td><td>" + t.carBrand.carBrandID + "</td><td>" + t.carBrand.name + "</td><td>" +
//            `<button type="button" onclick="remove(${t.CarsID})">Delete</button>` + "</td ></tr > ";
//    })

//}

function update() {
    document.querySelector("#updateformdiv").style.display = 'none';
    let names = document.querySelector("#carbrandnameupdate").value;
    fetch('http://localhost:50437/carbrand', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                name: names,
                carBrandID: carbrandidtoupdate
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


