# 🚀 HR Management System

![Status](https://img.shields.io/badge/status-active%20development-yellow) 
![.NET](https://img.shields.io/badge/.NET-8-blue)
![Architecture](https://img.shields.io/badge/architecture-vertical%20slicing%20%2B%20cqrs-ff69b4)
![License](https://img.shields.io/badge/license-MIT-blue)
![Audience](https://img.shields.io/badge/audience-enterprise%20HR%20%7C%20SaaS%20startups-orange)

**Modern HRMS built with Vertical Slice Architecture and CQRS patterns**

**⚠️ Active Development**  
Core modules being implemented with:
- 🍰 **Vertical Slicing** (feature-first organization)
- ↔️ **CQRS** (clear command/query separation)
- 🚀 **Redis-accelerated performance**

## 🎯 Target Audience

Built for:
- **Enterprise HR Teams** needing scalable workflows  
- **Sass Tech Startups** wanting modular foundation  
- **Dev Teams** studying Vertical Slice Architecture  

## ⚙️ Core Architecture

### 🍰 Vertical Slice Architecture
- Features organized as self-contained verticals (API → Domain → Infrastructure)
- No traditional horizontal layers (no "Services" folder)
- Minimal cross-slice dependencies

### ↔️ CQRS Implementation
- **MediatR** for command/query handling
- Separate read/write models
- Optimized query paths with **Redis caching**

### 🛠️ Key Technologies
| Component       | Technology Stack           |
|-----------------|----------------------------|
| Core Framework | .NET 8                     |
| Data Access    | EF Core + Dapper           |
| Caching        | Redis                      |
| Validation     | FluentValidation           |
| Real-Time      | SignalR                    |
| API Docs       | Swagger/OpenAPI            |

## 🏗️ Feature Modules
| Vertical Slice          | Key Capabilities                          |
|-------------------------|------------------------------------------|
| **Org Structure**       | Company → Branch → Dept hierarchy        |
| **Employee Lifecycle**  | Hiring → Promotion → Offboarding         |
| **Time Tracking**       | Shifts, Attendance, Overtime             |
| **Payroll Engine**      | Tax calculations + Payslip generation    |

## Why This Architecture?
- 💡 **Feature-focused development** - No layer jumping
- 🚫 **No abstraction pollution** - Only create interfaces when needed
- 🏎️ **Faster iteration** - Modify features without layer-wide changes
- 📊 **Clear ownership** - All feature code colocated

![Vertical Slice Diagram](https://github.com/your-repo/docs/raw/main/vsa-diagram.png) *(example diagram link)*

## 🚧 Project Status
Actively developing core verticals. Current focus:
1. Employee Management (80% complete)
2. Org Structure (60% complete)
3. Redis integration (in progress)
