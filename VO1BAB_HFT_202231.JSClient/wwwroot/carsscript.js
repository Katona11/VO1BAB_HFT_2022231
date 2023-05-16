let car = [];
let carbrandidtoupdate = -1;
     
    

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
            `<button type="button" onclick="remove(${t.carsID})">Delete</button>` +
            `<button type="button" onclick="showupdate(${t.carsID})">Update</button>` + "</td ></tr > ";
    })

}

function showupdate(id) {
    document.querySelector("#carbrandidupdate").value = car.find(t => t['carsID'] == id)['carBrandID'];
    document.querySelector("#licensePlateNumberupdate").value = car.find(t => t['carsID'] == id)['licensePlateNumber'];
    document.querySelector("#yearupdate").value = car.find(t => t['carsID'] == id)['year'];
    document.querySelector("#typeupdate").value = car.find(t => t['carsID'] == id)['type'];
    document.querySelector("#performanceInHPupdate").value = car.find(t => t['carsID'] == id)['performanceInHP'];

    document.querySelector("#updateformdiv").style.display = 'flex';
    carbrandidtoupdate = id;
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


function update() {
    document.querySelector("#updateformdiv").style.display = 'none';
    //let names = document.querySelector("#carname").value;
    let carbrandid = document.querySelector("#carbrandidupdate").value;
    let license = document.querySelector("#licensePlateNumberupdate").value;
    let years = document.querySelector("#yearupdate").value;
    let types = document.querySelector("#typeupdate").value;
    let hp = document.querySelector("#performanceInHPupdate").value;

    fetch('http://localhost:50437/cars', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                carsID: carbrandidtoupdate,
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
