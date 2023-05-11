let carbrand = [];

getData();

async function getData() {
    await fetch("http://localhost:50437/carbrand")
        .then(x => x.json())
        .then(y => {
            carbrand = y;
            display();

        });
}


function display() {
    carbrand.forEach(t => {
        document.querySelector("#resultarea").innerHTML +=
            "<tr><td>" + t.carBrandID + "</td><td>" + t.name + "</td></tr>";
    })
    
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


