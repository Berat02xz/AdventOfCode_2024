public class Solution {
    public string MergeAlternately(string word1, string word2) {

        int minLen = Math.Min(word1.Length,word2.Length);
        string result = "";

        for(int i=0;i<minLen;i++){
            result+=word1[i].ToString()+word2[i].ToString();
        }

        if(word1.Length>minLen){
            result+=word1.Substring(minLen);
        }else{
            result+=word2.Substring(minLen);
        }


        return result;

    }
}
