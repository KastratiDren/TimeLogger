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

<img width="710" alt="RegisterEndpoint" src="https://github.com/user-attachments/assets/6999032b-3f75-4340-8655-eb380571c3ec" />


---

### Login Endpoint
Authenticates a user by validating their credentials (email and password).

<img width="710" alt="LoginEndpoint" src="https://github.com/user-attachments/assets/fafb2088-7051-4a20-98d9-2d835ecb7129" />


---

### Check-In Endpoint
Allows a user to check in to the system, indicating their activity or presence.

<img width="710" alt="CheckinEndpoint" src="https://github.com/user-attachments/assets/1d638474-d3d3-44d9-bac7-76526b23dd24" />


---

### Delete User Endpoint
Deletes an existing user from the system by their unique identifier.

<img width="715" alt="DeletUserEndpoint" src="https://github.com/user-attachments/assets/30573f38-e25b-42fa-adf6-905dc623d4c1" />


---

### Get All Users Endpoint
Retrieves a list of all users registered in the system.

<img width="712" alt="GetAllUserEndpoint" src="https://github.com/user-attachments/assets/62d8e05e-a589-4070-a1fa-456442af2e3d" />


---

### Get User by ID Endpoint
Fetches details of a specific user based on their unique identifier.

<img width="713" alt="GetUserByIdEndpoint" src="https://github.com/user-attachments/assets/704bbd48-d412-4dd1-aa16-1c1ff6e55825" />


---


### Create Office Endpoint
Adds a new office to the system by providing details such as name and location.

<img width="709" alt="CreateOfficeEndpoint" src="https://github.com/user-attachments/assets/1cd0b69c-993c-445b-a631-7175bc0dbd5b" />


---

### Get All Offices Endpoint
Retrieves a list of all offices available in the system.

<img width="712" alt="GetAllOfficesEndpoint" src="https://github.com/user-attachments/assets/6febd503-7e12-403e-9e37-6ddc9f0a1d2a" />


---

### Get Office by ID Endpoint
Fetches details of a specific office based on its unique identifier.

<img width="713" alt="GetOfficeByIdEndpoint" src="https://github.com/user-attachments/assets/a2b710a1-eec5-4b93-8fa6-0205727b22c0" />


---

### Check-out Endpoint
Allows a user to check out of the system, indicating their activity is finished.

<img width="718" alt="CheckoutEndpoint" src="https://github.com/user-attachments/assets/845c6d56-8c77-4211-9ca5-3531ad3b21bb" />


---

### Get User's Attendance by User Id Endpoint

<img width="718" alt="GetUsersAttendanceById" src="https://github.com/user-attachments/assets/8668576b-d16d-4a3e-9b84-0689188d954a" />

### Get User's Average Checkin Time By User Id Endpoint

<img width="713" alt="Get AverageCheckInTime" src="https://github.com/user-attachments/assets/cb377e42-d5c4-4b7f-96c4-d8b532dc4f25" />


---

### Get User's Average Checkin Time By User Id Endpoint

<img width="713" alt="Get AverageCheckOutTime" src="https://github.com/user-attachments/assets/bbba3109-3526-45f5-bc9a-64608466899d" />


---

### Get User's Attendane for Specified Date Endpoint

<img width="712" alt="Get AttendanceByDate" src="https://github.com/user-attachments/assets/7bac72a6-5511-494e-90b6-f235b811e24f" />


---

### Get User's Daily Total Work Duration

<img width="707" alt="UserDailyWorkDuration" src="https://github.com/user-attachments/assets/e628e5b4-435d-4376-8ac4-6d940a92634b" />


---

### Get User's Weekly Total Work Duration

<img width="710" alt="GetWeeklyWorkHours" src="https://github.com/user-attachments/assets/ad1fda93-2542-4b08-9d81-bc4bbd6e0ac0" />


---


### Get User's Monthly Total Work Duration

<img width="711" alt="GetMonthlyWorkHours" src="https://github.com/user-attachments/assets/05b261d3-240c-4288-8147-af8589b69c58" />


---

### Create Room

<img width="710" alt="CreateRoom" src="https://github.com/user-attachments/assets/cc24cdc3-de68-4182-97d5-3f6b928e5209" />


---

### Get Room By Id

<img width="712" alt="GetRoomById" src="https://github.com/user-attachments/assets/832f82f7-4f6b-4d56-8089-4adcfb010546" />


---

### Get All Rooms

<img width="710" alt="GetAllRooms" src="https://github.com/user-attachments/assets/776caa73-8c09-46b7-9cd4-593a789dcdcd" />


---

### Get All Room Bookings

<img width="711" alt="GetAllRoomBookings" src="https://github.com/user-attachments/assets/b2195265-c70d-4b73-aa45-efcbf7a703f9" />


---

### Get All Room Bookigs for a specified Room

<img width="712" alt="GetRoomBookingsByRoom" src="https://github.com/user-attachments/assets/a7093b4f-4303-451b-b2f1-83b80cb5eda1" />

---

### Create a Room Booking

<img width="715" alt="CreateRoomBooking" src="https://github.com/user-attachments/assets/7f11b3a6-9c76-4555-b5ec-bab15c9d2531" />

---





