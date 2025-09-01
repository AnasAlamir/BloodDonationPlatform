# Hackathon-Vodafone-Digital-Blood-Bank

A digital blood donation platform built during the Summer Internship Program at **Eva Pharma**.  
The solution aims to **connect donors, hospitals, and administrators** in one ecosystem, enabling faster blood donation matching, tracking, and rewarding donors with a points-based incentive system.

---

## 🚀 Live Video Demo
[![Watch the video](https://img.youtube.com/vi/72zJD8TEdSw/hqdefault.jpg)](https://youtu.be/72zJD8TEdSw)

---

## 🖥️ Deployed API On MonsterASP.NET 
`https://hemolink.runasp.net`  
> Example: `https://hemolink.runasp.net/api/area/`

---

## 🌐 Frontend (Flutter Web)
The frontend applications (Donor, Hospital, and Admin portals) were developed separately using **Flutter Web** by our teammate.  
These applications consume the APIs exposed by this backend service.

- **Admin Portal**: [https://blood-bank-admin-18e25.web.app/](https://blood-bank-admin-18e25.web.app/)  
- **Hospital Portal**: [https://blood-bank-hospital.web.app/](https://blood-bank-hospital.web.app/)  
- **Donor Portal**: [https://blood-bank-donor-778b1.web.app/](https://blood-bank-donor-778b1.web.app/)  

> ⚠️ Note: This repository only contains the **backend (ASP.NET Core API)** implementation.  
> The Flutter frontend code is not included here and was handled in a separate workspace.

---

## 📂 Postman Workspace & Collections
Explore API endpoints via Postman:  
👉 [Blood Donation Platform Postman Collection](https://www.postman.com/anasteam-2506/workspace/blooddonationplatform/collection/43141018-49f1b0a1-ff3d-433a-af0b-330184e72e49?action=share&source=copy-link&creator=43141018)

---

## 📖 Project Story & Overview
This project was developed as part of the **EVA Pharma Internship (Health Tech Track)** in partnership with **Vodafone Business**.  

- The track started with **3 weeks of training sessions** delivered by Vodafone Business mentors (healthcare domain).  
- Followed by **3 weeks graduation project** at EVA Pharma with:  
  - **Technical** & **Business** follow-up.
  - Played Two Roles as (**Product Owners** & **Developers**)

As a team, we:  
1. Took the **challenge from Vodafone** (digital blood donation solution).  
2. Designed the **solution scope, workflows, and user stories**.  
3. Modeled the **ERD** and followed with implementation using:  
   - **Backend**: ASP.NET Core Web API with EF Core, 3-Tier Architecture, Repository Pattern, Unit of Work, deployed on MonsterASP.NET.  
   - **Flutter Frontend**: Used API EndPoints and integreated it with flutter (then deployed as web).  
4. Prioritized features due to time constraints:  
   - Built the **necessary parts** (donor request workflow, hospital management, inventory, points system).  
   - Deferred advanced features (e.g., full donor management, donor redeem offers).  

The project was ultimately **awarded Best Project** in the EVA Pharma Internship Program 2025. 🎉  

---

## 🎯 Features
### 👥 Donors  
- View profile & track donation history.  
- Receive and respond to blood donation requests (approve/reject).  
- Earn points per donation (e.g., 100 points).  

### 🏥 Hospitals  
- Create and manage blood donation requests.  
- Track inventory of blood types.  
- Match with available donors based on location and blood type.  

### 🛡️ Admins  
- Manage hospitals and intialize its inventory.  

---

## ⚙️ Tech Stack
- **Backend**: ASP.NET Core Web API (C#), Entity Framework Core, SQL Server  
- **Frontend**: Flutter (deployed web view)  
- **Database**: SQL Server with code-first approach  
- **Architecture**: 3-Tier Architecture, Repository Pattern, Unit of Work  
- **Hosting**:  
  - API → `MonsterASP.NET`
  - Frontend → `Firebase Hosting`
- **Collaboration**: GitHub, Postman  
- **QC**: Manual tests  

---

## 🏆 Hackathon Value
- Tackles a **critical healthcare problem**: blood shortage and inefficient donor-hospital communication.  
- Encourages a **community-driven donation culture** with rewards.  
- Provides a **scalable digital architecture** for adoption by NGOs, hospitals, and health authorities.  

---

## 📌 Future Improvements
- Donor management features.  
- Donor redeem offers flow.  
- AI-based donor-hospital matching.  
- Mobile-first app for real-time notifications.  
- Integration with **national health systems**.  
- Advanced gamification (leaderboards, donor levels).  

---