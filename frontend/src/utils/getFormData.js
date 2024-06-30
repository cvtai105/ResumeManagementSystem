export default function getFormData(form) {
    const formData = new FormData(form);
    const data = {};
    for (let key of formData.keys()) {
        data[key] = formData.get(key);
    }
    return data;
}