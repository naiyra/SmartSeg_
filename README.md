This is our MsC. project in Software engineering


---

## 🧪 Key Features

- 🔄 **Dataset Upload & Validation**  
  Uploads CSV datasets and validates format, types, and missing values.

- 🧹 **Data Cleaning & Encoding**  
  Handles nulls, normalizes formats, and applies label encoding for categorical features.

- 🧠 **AI-Assisted Feature Selection**  
  Uses OpenAI prompts to suggest optimal features for segmentation.

- 📊 **KMeans Clustering Engine**  
  Applies Scikit-learn’s KMeans via Python integration to segment customers.

- 📌 **Optimal K Estimation**  
  Uses Elbow and Silhouette methods to recommend the best number of clusters.

- 📋 **Readable Reporting**  
  Converts numeric cluster outputs into readable summaries (e.g., “Budget-conscious females aged 25-34”).

---

## 👥 Contributors

This project is distributed across 4 developers:

| Developer | Responsibility |
|----------|----------------|
| Dev A     | `DataHandling/` - Uploading, cleaning, encoding |
| Dev B     | `FeatureEngineering/` - Feature selection and extraction |
| Dev C     | `MachineLearning/` - Clustering logic and optimal K |
| Dev D     | `Reporting/` - Interpreting and visualizing clusters |

---

## 🚀 How to Run

1. Make sure you have [.NET 7+](https://dotnet.microsoft.com/en-us/download) installed.
2. Clone the repo:
   ```bash
   git clone https://github.com/your-org/SmartSeg.git
   cd SmartSeg

