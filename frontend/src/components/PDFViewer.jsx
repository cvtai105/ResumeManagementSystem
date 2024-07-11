// import React, { useState, useEffect } from 'react';
// import { Document, Page } from 'react-pdf';
// import 'react-pdf/dist/esm/Page/AnnotationLayer.css';

// const PdfViewer = ({ fileName }) => {
//     const [fileUrl, setFileUrl] = useState('');
//     const [error, setError] = useState(null);

//     useEffect(() => {
//         const fetchPdf = async () => {
//             try {
//                 const response = await fetch(`http://localhost:5231/api/hosoungtuyen/${fileName}`, {
//                     headers: {
//                         'Content-Type': 'application/pdf',
//                     },
//                 });

//                 if (!response.ok) {
//                     throw new Error('Network response was not ok');
//                 }

//                 const blob = await response.blob();
//                 setFileUrl(URL.createObjectURL(blob));
//             } catch (err) {
//                 setError(err.message);
//             }
//         };

//         fetchPdf();

//         return () => {
//             // Clean up the URL object
//             if (fileUrl) {
//                 URL.revokeObjectURL(fileUrl);
//             }
//         };
//     }, [fileName, fileUrl]);

//     if (error) {
//         return <p>Error loading PDF: {error}</p>;
//     }

//     return (
//         <div>
//             {fileUrl ? (
//                 <Document file={fileUrl}>
//                     <Page pageNumber={1} />
//                 </Document>
//             ) : (
//                 <p>Loading PDF...</p>
//             )}
//         </div>
//     );
// };

// export default PdfViewer;
