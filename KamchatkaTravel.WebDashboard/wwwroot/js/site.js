let form = document.getElementById("#tourForm");
if (form != null) {
    form.addEventListener('submit', (event) => { event.preventDefault(); addTour(); });
}

let dayForm = document.getElementById("#dayForm");
if (dayForm != null) {
    dayForm.addEventListener('submit', (event) => { event.preventDefault(); addDay(); });
}

async function addTour() {

    const formData = new FormData(form);

    url = 'api/Tour/CreateTour';

    let responce = await fetch(url,
        {
            method: 'post',
            headers: {
                Accept: "multipart/form-data",
            },
            body: formData
        }
    )

    let result = await responce.status;

    if (result == 200) {
        document.getElementById("#ModalTitle").innerHTML = 'Тур создан.';
        document.getElementById("#ModalText").innerHTML = '';
        modal().open("#m-success");
    }
    else {
        document.getElementById("#ModalTitle").innerHTML = 'Ошибка!';
        document.getElementById("#ModalText").innerHTML = 'Сервер не отвечает, попробуйте создать тур позже.';

        modal().open("#m-success");
    }
}

async function addDay() {
    const formData = new FormData(dayForm);
    formData.append("tourID", document.getElementById("#tourSelect").value)

    url = 'api/Tour/CreateDay';

    let responce = await fetch(url,
        {
            method: 'post',
            headers: {
                Accept: "multipart/form-data",
            },
            body: formData
        }
    )

    let result = await responce.status;

    if (result == 200) {
        document.getElementById("#ModalTitle").innerHTML = 'День создан.';
        document.getElementById("#ModalText").innerHTML = '';
        modal().open("#m-success");
    }
    else {
        document.getElementById("#ModalTitle").innerHTML = 'Ошибка!';
        document.getElementById("#ModalText").innerHTML = 'Сервер не отвечает, попробуйте создать день позже.';

        modal().open("#m-success");
    }
}

function modal() {
    return new HystModal({
        linkAttributeName: "data-hystmodal",
        waitTransitions: true,
    })
}

async function loadTour() {
    const batchTrack = document.getElementById("#tourSelect");

    url = 'api/Tour/GetTours';

    let response = await fetch(url,
        {
            method: 'get'
        }
    )

    let data = await response.json();
    let status = await response.status;

    if (status == 200) {
        data.tours.forEach(option => {
            const newOption = document.createElement("option");
            newOption.value = option.id;
            newOption.text = option.name;
            batchTrack.appendChild(newOption);

        });
    }
    else {
        document.getElementById("#ModalTitle").innerHTML = 'Ошибка!';
        document.getElementById("#ModalText").innerHTML = 'Сервер не отвечает, попробуйте создать тур позже.';

        modal().open("#m-success");
    }
}

loadTour();