# Phone Book Application with File Storage

## Table of Contents
- [Description](#Description)
- [Features](#Features)
- [Classes and Methods](#classes-and-methods)

## Description
The Phone Book Application is a console app designed to manage contacts efficiently. It allows users to add, remove, update, list, load and save contacts. The application stores all the data a the file. Users interact with the program via the console

## Features
- **Add Contact:** Allows users to add a new contact with a name and phone number to the phone book.
- **Remove Contact:** Allows users to removes given existing contact from the phone book
- **Update Contact:** Allows users to update contact.
- **Load Contact:** Allows users to load and see contacts in the console.
- **Persistent Storage:** Contacts are saved in a JSON file.

## Classes and methods
### Contact class
Represents Data class for Phonebook

### Attributes
- `name` - The name of the contact
- `phoneNumber` - The phone number of the contact

### Methods
`bool Equals()`, `int GetHashCode()`, `string ToString()` are override

### IContactsHandlerForFile interface

### Methods