Public Class ClassMasterSilhouette
    Sub openSHTList()
        Dim id_code_fg_sht = get_setup_field("id_code_fg_sht")
        FormCodeTemplateEdit.id_pop_up = "6"
        FormCodeTemplateEdit.id_template_code = "13"
        FormCodeTemplateEdit.id_code = id_code_fg_sht
        FormCodeTemplateEdit.ShowDialog()
    End Sub
End Class
