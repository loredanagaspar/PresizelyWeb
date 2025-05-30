function ShowConfirmationModal() {
    bootstrap.Modal.getOrCreateInstance(document.getElementById('bsConfirmationModal')).show();

}

function HideConfirmationModal() {
    bootstrap.Modal.getOrCreateInstance(document.getElementById('bsConfirmationModal')).hide();

}

window.addRefreshAnimation = (elementId) => {
    let element = document.getElementById(elementId);
    if (element) {
        element.classList.add("rotate-icon");
    }
};

window.removeRefreshAnimation = (elementId) => {
    let element = document.getElementById(elementId);
    if (element) {
        setTimeout(() => {
            element.classList.remove("rotate-icon");
        }, 500); 
       

    }
};
console.log("common.js loaded");