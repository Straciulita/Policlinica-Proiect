# 🏥 Aplicație de Gestionare Policlinică

O aplicație desktop dezvoltată în C# pentru gestionarea eficientă a datelor dintr-o policlinică, care combină programarea orientată pe obiecte cu concepte de baze de date relaționale. Proiectul oferă o interfață prietenoasă pentru angajați și pacienți, facilitând procesele de programare, consultare și administrare medicală.

---

## 🔧 Tehnologii utilizate

- **C# și Windows Forms** – pentru crearea interfeței grafice (GUI)
- **MySQL** – pentru stocarea și gestionarea datelor
- **MySQL Connector/NET** – pentru conectarea aplicației la baza de date
- **Programare orientată pe obiecte** – pentru o structură clară și extensibilă

---

## 🧠 Funcționalități principale

### ✅ Pentru angajați:
- Gestionarea programărilor și consultațiilor
- Vizualizarea listei de pacienți
- Introducerea și actualizarea diagnosticului și tratamentului
- Autentificare pe baza unui cont de acces

### ✅ Pentru pacienți:
- Acces rapid fără cont
- Crearea unui cont personal opțional pentru gestionarea mai ușoară a programărilor
- Programări online
- Vizualizarea istoricului medical (consultații, tratamente)

---

## 👥 Roluri în aplicație

- **Administrator**: Gestionare completă a angajaților și a conturilor
- **Angajat**: Acces la programări și informații despre pacienți
- **Pacient**: Acces la programări și istoric personal

---

## 📦 Structura bazei de date

Tabelele principale:
- `Pacient`
- `Angajat`
- `Programari`
- `Consultatie`
- `Acces`
- `ConturiPacient`

Relațiile dintre tabele sunt gestionate prin chei străine pentru a asigura integritatea datelor și coerența funcționalităților.

---

## 🔐 Validarea datelor

- Verificarea formatului CNP, e-mail și câmpuri obligatorii
- Constrângeri în MySQL pentru unicitate și consistență
- Validări atât pe partea clientului (interfață) cât și în backend

---

## 🖼️ Capturi de ecran

![image](https://github.com/user-attachments/assets/23e30fa7-e5c2-4071-a136-f6b9dd547140)
![image](https://github.com/user-attachments/assets/7222a6a2-3aca-4368-91a0-2c559721f985)
![image](https://github.com/user-attachments/assets/ad46601c-9580-4846-bfe5-5ee351f17515)
![image](https://github.com/user-attachments/assets/1f8d18c3-0880-4cd9-b15d-2777099d8b9b)
![image](https://github.com/user-attachments/assets/efbfaae9-fac1-4a4c-b077-4bb151b7118c)
![image](https://github.com/user-attachments/assets/be806192-35db-45fc-805a-56dffa14c726)
![image](https://github.com/user-attachments/assets/96562a66-d612-456e-a3dd-ed4cc686a3a0)

