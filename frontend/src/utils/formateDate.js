function formateDate(dateString) {
    const date = new Date(dateString);
    const day = date.getDate().toString().padStart(2, '0');
    const month = (date.getMonth() + 1).toString().padStart(2, '0'); // Months are zero-based
    const year = date.getFullYear();

    if (isNaN(day) || isNaN(month) || isNaN(year)) {
        return '';
    }
    
    return `${day}/${month}/${year}`;
}

export default formateDate;