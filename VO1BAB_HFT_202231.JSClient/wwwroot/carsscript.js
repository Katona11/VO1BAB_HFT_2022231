let car = [];

getData();

//async function getData() {
//    await fetch("http://localhost:50437/cars")
//        .then(x => x.json())
//        .then(y => {
//            car = y;
//            display();

//        });
//}

async function getData() {
    let resp = await fetch("http://localhost:50437/cars");
    let data = await resp.json();
    car = data;
    display();

    
    
}


function display() {
    document.querySelector("#carsarea").innerHTML = "";
    car.forEach(t => {
        document.querySelector("#carsarea").innerHTML +=
            "<tr><td>" + t.carsID + "</td><td>" + t.carBrandID + "</td><td>" + t.licensePlateNumber + "</td><td>" + t.year + "</td><td>" + t.type + "</td><td>" + t.performanceInHP + "</td><td>" + t.carBrand.carBrandID + "</td><td>" + t.carBrand.name + "</td><td>" +
            `<button type="button" onclick="remove(${t.carsID})">Delete</button>` + "</td ></tr > ";
    })

}

function remove(id) {
    fetch('http://localhost:50437/cars/' + id, {
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
    let names = document.querySelector("#carname").value;
    let carbrandid = document.querySelector("#carbrandid").value;
    let license = document.querySelector("#licensePlateNumber").value;
    let years = document.querySelector("#year").value;
    let types = document.querySelector("#type").value;
    let hp = document.querySelector("#performanceInHP").value;
    
    fetch('http://localhost:50437/cars', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                
                carBrandID: carbrandid,
                licensePlateNumber: license,
                year: years,
                type: types,
                performanceInHP: hp,
                





                
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
