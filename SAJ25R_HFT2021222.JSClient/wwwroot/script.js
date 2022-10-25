let guns = []

getdata()

async function getdata() {
    await fetch('http://localhost:7671/gun')
        .then(x => x.json())
        .then(y => {
            guns = y;
            console.log(guns)
            display()
        });
}





function display() {
    document.getElementById("resultarea").innerHTML = "";
    guns.forEach(g => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + g.serialNumber + "</td><td>" + g.ownerId + "</td><td>" + g.gunName
            + "</td><td>" + g.caliber + "</td><td>" + g.weight + "</td><td>" + g.price + "</td><td>" +
            `<button type="button" onclick="remove(${g.serialNumber})">Delete</button>`
             + "</td></tr>";
        console.log(g.gunName)
    });
}

function remove(id) {
    fetch('http://localhost:53910/actor/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function create() {
    let name = document.getElementById('gunName').value
    let cal = document.getElementById('caliber').value
    let wei = document.getElementById('weight').value
    let ownid = document.getElementById('ownerID').value
    let prc = document.getElementById('price').value


    fetch('http://localhost:7671/gun', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                gunName: name,
                caliber: cal,
                weight: wei,
                ownerID: ownid,
                price: prc
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
    

}