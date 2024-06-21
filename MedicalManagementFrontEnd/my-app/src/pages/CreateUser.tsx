// src/pages/CreateUser.tsx
import React, { useState } from 'react';
import { Users } from '../api/axios';

const CreateUser: React.FC = () => {
  const [userData, setUserData] = useState({
    Username: '',
    Password: '',
    Email: '',
    Name: '',
    DateOfBirth: '',
    Gender: 'Male', // or 'Female', adjust based on your enum
    PhoneNumber: '',
  });

  const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
    const { name, value } = e.target;
    setUserData((prevState) => ({
      ...prevState,
      [name]: value,
    }));
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const response = await Users.createUser(userData);
      console.log('User created successfully:', response);
    } catch (error) {
      console.error('Error creating user:', error);
    }
  };

  return (
    <div>
      <h2>Create User</h2>
      <form onSubmit={handleSubmit}>
        <label>
          Username:
          <input type="text" name="Username" value={userData.Username} onChange={handleChange} required />
        </label>
        <label>
          Password:
          <input type="password" name="Password" value={userData.Password} onChange={handleChange} required />
        </label>
        <label>
          Email:
          <input type="email" name="Email" value={userData.Email} onChange={handleChange} required />
        </label>
        <label>
          Name:
          <input type="text" name="Name" value={userData.Name} onChange={handleChange} required />
        </label>
        <label>
          Date of Birth:
          <input type="date" name="DateOfBirth" value={userData.DateOfBirth} onChange={handleChange} required />
        </label>
        <label>
          Gender:
          <select name="Gender" value={userData.Gender} onChange={handleChange} required>
            <option value="Male">Male</option>
            <option value="Female">Female</option>
          </select>
        </label>
        <label>
          Phone Number:
          <input type="tel" name="PhoneNumber" value={userData.PhoneNumber} onChange={handleChange} required />
        </label>
        <button type="submit">Create User</button>
      </form>
    </div>
  );
};

export default CreateUser;
