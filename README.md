# Check-In Check-Out App

A basic app for managing employee check-ins and check-outs, featuring an admin dashboard, employee time tracking, and performance stats.

## Features

- **Admin Dashboard**  
  Manage employee profiles, track attendance, and view stats.

- **Calculate Time**  
  Calculates total hours worked based on check-in and check-out times.

- **Check In / Check Out**  
  Employees can log check-ins and check-outs with timestamps.

- **Display Stats**  
  View summarized stats, such as total hours worked in day, week or month and attendance history.

- **Employee Profile**  
  Manage and view individual employee details.

- **Login / Registration**  
  Secure employee login and registration for new users.

## Documentation Diagrams

### Admin Dashboard
![AdminDashboard](https://github.com/user-attachments/assets/6df643c8-6272-45f9-8246-07887ee02254)

---

### Calculate Time
![CalculateTime](https://github.com/user-attachments/assets/94a54571-3a98-4a23-a34a-ec85872482c6)

---

### Check-In
![CheckIn](https://github.com/user-attachments/assets/449d6c58-7557-45ef-9534-ae9efe4c1f07)

---

### Check-Out
![CheckOut](https://github.com/user-attachments/assets/6670e09a-98d1-43e8-8775-18967ca09e16)

---

### Display Stats
![DisplayStats](https://github.com/user-attachments/assets/fbc33e2c-c952-4fa5-be60-3021099c7d59)

---

### Employee Profile
![EmployeeProfile](https://github.com/user-attachments/assets/31779ecf-9dc6-4ff4-a47f-52fe5afce1c8)

---

### Login
![LogIn](https://github.com/user-attachments/assets/c891ecf4-ac42-4ce1-9d22-b16db68821c1)

---

### Registration
![Registration](https://github.com/user-attachments/assets/0b72a3b0-6505-4bcb-88c9-28d86f91bbd0)

---


## API Endpoint Documentation

### Register Endpoint
Registers a new user in the system by providing necessary information such as name, surname, username, email, and password.

<img width="712" alt="UserRegistration" src="https://github.com/user-attachments/assets/cb015156-accb-4782-abbc-477254fb5288" />

---

### Login Endpoint
Authenticates a user by validating their credentials (email and password).

<img width="711" alt="LoginUser" src="https://github.com/user-attachments/assets/1196eb7e-5008-4b33-b354-c03ecb79d1ee" />

---

### Check-In Endpoint
Allows a user to check in to the system, indicating their activity or presence.

<img width="712" alt="Checkin" src="https://github.com/user-attachments/assets/e5dae78c-0ef3-4f1a-afe0-c9b18be26110" />

---

### Delete User Endpoint
Deletes an existing user from the system by their unique identifier.

<img width="739" alt="DeleteUser" src="https://github.com/user-attachments/assets/19f58b2b-0390-469d-8f8d-ed435c3090c9" />

---

### Get All Users Endpoint
Retrieves a list of all users registered in the system.

<img width="736" alt="GetUsers" src="https://github.com/user-attachments/assets/a8ff2619-b8e7-44b2-a64c-8137a365d8c7" />

---

### Get User by ID Endpoint
Fetches details of a specific user based on their unique identifier.

<img width="728" alt="GetUserById" src="https://github.com/user-attachments/assets/3f810adb-c716-4bc1-b85e-8203cd4c0c48" />

---


### Create Office Endpoint
Adds a new office to the system by providing details such as name and location.

<img width="713" alt="CreateOffice" src="https://github.com/user-attachments/assets/30dd29cb-3d8b-4669-bcdf-d8285c349d05" />

---

### Get All Offices Endpoint
Retrieves a list of all offices available in the system.

<img width="719" alt="GetOffices" src="https://github.com/user-attachments/assets/01cad6d3-d2ff-4fdc-87be-0f9db5b84ee7" />

---

### Get Office by ID Endpoint
Fetches details of a specific office based on its unique identifier.

<img width="719" alt="GetOfficeById" src="https://github.com/user-attachments/assets/4836ca93-fdcf-4dcd-96ba-4e472f06f388" />

---

### Check-out Endpoint
Allows a user to check out of the system, indicating their activity is finished.

<img width="713" alt="Checkout" src="https://github.com/user-attachments/assets/8ecd2b43-780c-499a-bc90-b5d97a12a619" />

---

### Get User's Attendance by User Id Endpoint

<img width="712" alt="GetAttendanceByUserID" src="https://github.com/user-attachments/assets/bf97cc1a-84de-4f8f-8236-43428418e426" />

---

### Get User's Average Checkin Time By User Id Endpoint

<img width="714" alt="AverageCheckinTime" src="https://github.com/user-attachments/assets/edacfb50-5496-4c7d-8ed3-54279b149ae6" />

---

### Get User's Average Checkout Time By User Id Endpoint

<img width="715" alt="AverageCheckoutTime" src="https://github.com/user-attachments/assets/fed3244f-d83d-4705-8c85-06f4eec5a953" />

---

### Get Attendane for a Specified Date Endpoint

<img width="712" alt="GetAttendanceByDate" src="https://github.com/user-attachments/assets/c03b917e-a4d6-4e82-af14-46d0e668c81a" />

---

### Get User's Daily Total Work Duration

<img width="712" alt="GetDailyWorkDuration" src="https://github.com/user-attachments/assets/1ca77284-a42d-4ad9-a6f4-770fef5b6f7e" />

---

### Get User's Weekly Total Work Duration

<img width="711" alt="GetWeeklyWorkDuration" src="https://github.com/user-attachments/assets/6c8f1e7a-3fc7-4154-8109-086c2c12f8ef" />

---

### Get User's Monthly Total Work Duration

<img width="712" alt="GetMonthlyWorkDuration" src="https://github.com/user-attachments/assets/766c7a94-d5c2-4cf2-8b5b-52ca171ecddd" />

---

### Create Room

<img width="721" alt="CreateRoom" src="https://github.com/user-attachments/assets/6f678051-350d-49bb-b078-afff75df8842" />

---

### Get Room By Id

<img width="724" alt="GetRoomById" src="https://github.com/user-attachments/assets/2a52311a-8525-4487-a39e-e4206eb061ab" />

---

### Get All Rooms

<img width="719" alt="GetRooms" src="https://github.com/user-attachments/assets/b8db6e93-6b15-450b-824f-03eef5198593" />

---

### Get All Room Bookings

<img width="725" alt="GetRoomBookings" src="https://github.com/user-attachments/assets/3bc13f69-45bb-4e18-acaa-45c8d2078584" />

---

### Get All Room Bookigs for a specified Room

<img width="722" alt="GetRoomBookingByRoomById" src="https://github.com/user-attachments/assets/ba5cae74-97d4-473e-abb0-37bcc7ac038e" />

---

### Create a Room Booking

<img width="730" alt="CreateRoomBookings" src="https://github.com/user-attachments/assets/6665c106-6fa9-430b-b58b-32d07771dec8" />

---





