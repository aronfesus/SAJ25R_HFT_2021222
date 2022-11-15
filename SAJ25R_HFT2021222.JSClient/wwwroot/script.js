let guns = []
let connection = null;

let gunIdToUpdate = -1;

getdata()
setupSignalR();



function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:7671/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("GunCreated", (user, message) => {
        getdata();
    });

    connection.on("GunDeleted", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();

    connection.on("GunUpdated", (user, message) => {
        getdata();
    });

}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

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
        `<button type="button" onclick="remove(${g.serialNumber})">Delete</button>` +
        `<button type="button" onclick="showupdate(${g.serialNumber})">Update</button>`
             + "</td></tr>";
        console.log(g.gunName)
    });
}

function remove(id) {
    fetch('http://localhost:7671/gun/' + id, {
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

function showupdate(id) {
    g = guns.find(t => t['serialNumber'] == id);
    document.getElementById('gunNametoupdate').value = g.gunName;
    document.getElementById('ownerIDtoupdate').value = g.ownerId;
    document.getElementById('calibertoupdate').value = g.caliber;
    document.getElementById('weighttoupdate').value = g.weight;
    document.getElementById('pricetoupdate').value = g.price;
    document.getElementById('updateformdiv').style.display = 'flex';
    gunIdToUpdate = id;
    
}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let name = document.getElementById('gunNametoupdate').value
    let cal = document.getElementById('calibertoupdate').value
    let wei = document.getElementById('weighttoupdate').value
    let ownid = document.getElementById('ownerIDtoupdate').value
    let prc = document.getElementById('pricetoupdate').value


    fetch('http://localhost:7671/gun', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                gunName: name,
                caliber: cal,
                weight: wei,
                ownerID: ownid,
                price: prc,
                serialNumber: gunIdToUpdate
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