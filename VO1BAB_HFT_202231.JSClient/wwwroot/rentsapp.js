let rents = [];
let carbrandidtoupdate = -1;
getData();

async function getData() {
    let resp = await fetch("http://localhost:50437/rents");
    let data = await resp.json();
    rents = data;
    display();



}

function display() {
    document.querySelector("#rentsarea").innerHTML = "";
    rents.forEach(t => {
        document.querySelector("#rentsarea").innerHTML +=
            "<tr><td>" + t.rentId + "</td><td>" + t.rentTime + "</td><td>" + t.ownerName + "</td><td>" + t.carsID + "</td><td>" +
            `<button type="button" onclick="remove(${t.rentId})">Delete</button>` +
            `<button type="button" onclick="showupdate(${t.rentId})">Update</button>` + "</td ></tr > ";
    })

}

function showupdate(id) {
    document.querySelector("#renttimeupdate").value = rents.find(t => t['rentId'] == id)['rentTime'];
    document.querySelector("#ownernameupdate").value = rents.find(t => t['rentId'] == id)['ownerName'];
    document.querySelector("#carsidupdate").value = rents.find(t => t['rentId'] == id)['carsID'];
    document.querySelector("#updateformdiv").style.display = 'flex';
    carbrandidtoupdate = id;
}

function remove(id) {
    fetch('http://localhost:50437/rents/' + id, {
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
    let renttime = document.querySelector("#renttime").value;
    let ownername = document.querySelector("#ownername").value;
    let carsid = document.querySelector("#carsid").value;



    fetch('http://localhost:50437/rents', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                rentTime: renttime,
                ownerName: ownername,
                carsID: carsid


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
    let renttime = document.querySelector("#renttimeupdate").value;
    let ownername = document.querySelector("#ownernameupdate").value;
    let carsid = document.querySelector("#carsidupdate").value;



    fetch('http://localhost:50437/rents', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                rentId: carbrandidtoupdate,
                rentTime: renttime,
                ownerName: ownername,
                carsID: carsid


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


