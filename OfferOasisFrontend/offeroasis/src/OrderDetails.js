import React, { useEffect, useState } from 'react';

export default function OrderDetails() {
    const token = localStorage.getItem('token');
    const [responseStatus, setResponseStatus] = useState(null);

    useEffect(() => {
        fetch('https://localhost:7193/products', {
            method: 'GET',
            headers: {
                'Authorization': `Bearer ${token}`,
                'Content-Type': 'application/json'
            },
        })
            .then(response => {
                setResponseStatus(response.status); 
            })
            .catch(error => {
                console.log(error);
            });
    }, []);

    return (
        <div>
            {responseStatus === 200 ? (
                // Render your product details here if the response is OK (status code 200)
                <div class="w-full max-w-smborder border-gray-200 rounded-lg shadow dark:bg-gray-800 dark:border-gray-700">
                  List of previous orders!
                </div>
            ) : (
                // Render "You need to login" message if the response is not OK
                <p>You need to login</p>
            )}
        </div>
    );
}
