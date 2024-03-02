import React, { useState } from 'react';
import B from './B';

const A = () => {
    const [x, setX] = useState(0);

    const handleChangeX = (y) => {
        setX(y);
    };

    return (
        <div>
            <h1>Component A</h1>
            <p>Giá trị x: {x}</p>
            <B x={x} handleChange={handleChangeX} />
        </div>
    );
};

export default A;

