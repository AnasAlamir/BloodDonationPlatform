# Blood Donation App - API Endpoints Specification
## Hospital Endpoints
### POST /api/hospital/login
> hospital login

**Request:**
```json
{
  "phoneNumber": "01000000000",
}
```
**Response:**
```json
{
  "id": 1,
  "name": "El-Helal",
  "phoneNumber": "01000000000",
  "areaId": maadi,
  "minimumBloodQuantityByLiter": "10"
}
```
### GET /api/hospital/{id}                             .
> Retrieves hospital information and details

**Response:**
```json
{
  "id": 1,
  "name": "El-Helal",
  "phoneNumber": "01000000000",
  "areaId": maadi,
  "minimumBloodQuantityByLiter": "10"
}
```
### GET /api/hospital/get-all-by-name
> Retrieves a list of all hospitals by name in the system

**Response:**
```json
{
  "hospitals": [
    {
      "id": 1,
      "name": "El-Helal",
    },
    {
      "id": 2,
      "name": "El-Salam",
    }
  ]
}
```
### GET /api/hospital
> Retrieves a list of all hospitals in the system

**Response:**
```json
{
  "hospitals": [
    {
      "id": 1,
      "name": "El-Helal",
      "phoneNumber": "01000000000",
      "areaId": maadi,
      "minimumBloodQuantityByLiter": "10"
    },
    {
      "id": 2,
      "name": "El-Salam",
      "phoneNumber": "01100000000",
      "areaId": maadi,
      "minimumBloodQuantityByLiter": "15"
    }
  ]
}
```
### POST /api/hospital/add-hospital
>[Authorize(Roles = "Admin")] 
> add new hospital in the system
**Request:**
```json
{
  "name": "El-Helal",
  "phoneNumber": "01000000000",
  "areaId": 1,
  "minimumBloodQuantityByLiter": "10",
  "createdById": 2 
}
```
### PUT /api/hospital/{id}                  .
>[Authorize(Roles = "Admin, Hospital")] 
> edit hospital

**Request:**
```json
{
  "name": "El-Helal",
  "phoneNumber": "01000000000",
  "areaId": 1,
  "minimumBloodQuantityByLiter": "10",
}
```
### DELETE /api/hospital/{id}                  .
>[Authorize(Roles = "Admin")] 
> DELETE hospital
---
## Donor Endpoints
### POST /api/donor/login
> donor login

**Request:**
```json
{
  "phoneNumber": "01000000000",
}
```
**Response:**
```json
{
  "id": 1,
  "fullName": "Ahmed Hassan",
  "phoneNumber": "01012345678",
  "ssn": "11111111111111",
  "dateOfBirth": "2024-07-26",
  "lastDonationDate": "2024-07-26",
  "gender" : "male",
  "bloodType": "A+",
  "areaId": maadi,
  "points": 150
}
```
### Get /api/donor/{id}                  .
>[Authorize(Roles = "Donor, Hospital")] 
> Get donor by id

**Request:**
```json
{
  "fullName": "Ahmed Hassan",
  "phoneNumber": "01012345678",
  "ssn": "11111111111111",
  "dateOfBirth": "2024-07-26",
  "lastDonationDate": "2024-07-26",
  "gender" : "male",
  "bloodType": "A+",
  "areaId": maadi,
  "points": 150
}
```
---
## donation-request Endpoints

<!-- ### GET /api/donation-request/{id}         .   
>[Authorize(Roles = "Donor")]             
> Get donation-request by id  

**Request:**
```json
{
    "id": 1,
    "bloodType": "A+",
    "quantityNeeded": 2,
    "createdAt": "2024-07-26",
    "hospitalId": 2
}
``` -->
### GET /api/donation-request/open-requests   
>[Authorize(Roles = "Hospital")]             
> Get open donation-request count 

**Request:**
```json
{
    "numberofOpenRquests": 5
}
```
### GET /api/donation-request/pending-requests   
>[Authorize(Roles = "Hospital")]             
> Get pending donation-request count 

**Request:**
```json
{
    "numberofPendingRquests": 2
}
```
### Post /api/donation-request/   
>[Authorize(Roles = "Hospital")]             
> create donation-request

**Request:**
```json
{
    "bloodType": "A+",
    "quantityNeeded": 2,
    "hospitalId": 2
}
```
### GET /api/donation-request/hospital/active/{id}           .  
>[Authorize(Roles = "Hospital")]                
> Get active (recent) donation-request by hospital id 

**Request:**
```json
{
  [
    {
      "id": 1,
      "bloodType": "A+",
      "quantityNeeded": 2,
      "createdAt": "2024-07-26",
      "requestStatus": "pending"
    },
    {
      "id": 2,
      "bloodType": "AB+",
      "quantityNeeded": 4,
      "createdAt": "2024-07-26",
      "requestStatus": "In Progress"
    }
  ]
}
```
### GET /api/donation-request/hospital/completed/{id}           .  
>[Authorize(Roles = "Hospital")]                
> Get completed (past) donation-request by hospital id 

**Request:**
```json
{
  [
    {
      "id": 1,
      "bloodType": "A+",
      "quantityNeeded": 2,
      "createdAt": "2024-07-26",
      "requestStatus": "completed"
    },
    {
      "id": 2,
      "bloodType": "AB+",
      "quantityNeeded": 4,
      "createdAt": "2024-07-26",
      "requestStatus": "completed"
    }
  ]
}
```
### GET /api/donation-request/donor/{id}           .  
>[Authorize(Roles = "donor")]                
Get donation-requests by donor id 
if DonorApprovalStatus rejected wil not come with this list
list contains only null as not answerd yet and approved

**Request:**
```json
{
  [
    {
      "id": 1,
      "bloodType": "A+",
      "area": "maadi",
      "createdAt": "2024-07-26",
      "hospitalName": "El-Salam",
      "DonorApprovalStatus":null   
    },
    {
      "id": 2,
      "bloodType": "AB+",
      "area": "maadi",
      "createdAt": "2024-07-26",
      "hospitalName": "El-Helal",
      "DonorApprovalStatus": "accepted"
    }
  ]
}
```
### Post /api/donation-request/donor
>[Authorize(Roles = "donor")]             
> donor accept/reject donation-request

**Request:**
```json
{
    "donorId": 1,
    "donationRequestId": 2,
    "DonorApprovalStatus": "accepted"
}
```
---
## BloodType Endpoints
### GET /api/blood-type/{id}         .               
> Get blood-type by id  

**Request:**
```json
{
    "id": 1,
    "type": "A+"
}
```
### GET /api/blood-type                 
> Get blood-types 

**Request:**
```json
{
  [
    {
      "id": 1,
      "type": "A+"
    },
    {
      "id": 2,
      "type": "B+"
    }
  ]
}
```
---
## area Endpoints
### GET /api/area/{id}         .               
> Get area by id  

**Request:**
```json
{
    "id": 1,
    "type": "maadi"
}
```
### GET /api/area                 
> Get areas

**Request:**
```json
{
  [
    {
      "id": 1,
      "type": "maadi"
    },
    {
      "id": 2,
      "type": "dokki"
    }
  ]
}
```
---
## Inventory Endpoints
### GET /api/inventory/hospital/{id}         .               
> Get Inventory by hospital id  

**Request:**
```json
[
  {
    "id": 1,
    "bloodType": "A+",
    "quantity": "5",
    "expirationDate": "2024-07-26",
    "satus": "low stock"
  },
  {
    "id": 2,
    "bloodType": "AB+",
    "quantity": "10",
    "expirationDate": "2024-07-26",
    "satus": "available"
  },
]
```
### PUT /api/inventory/{id}         .               
> edit Inventory by id  

**Request:**
```json
{
  "quantity": "5",
  "expirationDate": "2024-07-26",
  "hospitalId": "1"
}
```
---
