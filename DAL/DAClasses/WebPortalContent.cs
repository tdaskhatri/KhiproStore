using eLearning.DAL.DataAccess;

namespace eLearning.DAL.DAClasses
{
    class WebPortalContent
    {
        private DAWebPortalContent DA = new DAWebPortalContent();
        public string GetPageContent(string PageName)
        {
            return this.DA.GetPageContent(PageName);
        }
    }
}
