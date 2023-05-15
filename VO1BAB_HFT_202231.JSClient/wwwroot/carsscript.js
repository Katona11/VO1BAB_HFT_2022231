/*let car = [];*/

/*getData();*/

//async function getData() {
//    await fetch("http://localhost:50437/cars")
//        .then(x => x.json())
//        .then(y => {
//            car = y;
//            display();

//        });
//}

//async function getData() {
//    let resp = await fetch("http://localhost:50437/cars");
//    let data = await resp.json();
//    car = data;
//    display();

    
    
/*}*/


//function display() {
//    document.querySelector("#carsarea").innerHTML = "";
//    car.forEach(t => {
//        document.querySelector("#carsarea").innerHTML +=
//            "<tr><td>" + t.CarsID + "</td><td>" + t.CarBrandID + "</td><td>" + t.LicensePlateNumber + "</td><td>" + t.Year + "</td><td>" + t.Type + "</td><td>" + t.PerformanceInHP + "</td><td>" + t.carBrand.CarBrandID + "</td><td>" + t.carBrand.name + "</td><td>" +
//                `<button type="button" onclick="remove(${t.CarsID})">Delete</button>` + "</td ></tr > ";
//    })

//}

//function remove(id) {
//    fetch('http://localhost:50437/cars/' + id, {
//        method: 'DELETE',
//        headers: {
//            'Content-Type': 'application/json',
//        },
//        body: null
//    })
//        .then(response => response)
//        .then(data => {

//            console.log('Success:', data);
//            getData();
//        })
//        .catch((error) => {
//            console.error('Error:', error);
//        });
//}


//function create() {
//    let names = document.querySelector("#carbrandname").value;
//    fetch('http://localhost:50437/carbrand', {
//        method: 'POST',
//        headers: {
//            'Content-Type': 'application/json',
//        },
//        body: JSON.stringify(
//            {
//                name: names
//            }),
//    })
//        .then(response => response)
//        .then(data => {

//            console.log('Success:', data);
//            getData();
//        })
//        .catch((error) => {
//            console.error('Error:', error);
//        });


//}
