let rents = [];

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
            `<button type="button" onclick="remove(${t.rentId})">Delete</button>` + "</td ></tr > ";
    })

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


